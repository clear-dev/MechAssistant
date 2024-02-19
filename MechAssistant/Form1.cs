using MechAssistant.Models;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Configuration.Internal;

namespace MechAssistant
{
    public partial class Form1 : Form
    {
        internal static Dictionary<string, Category>? Categories;
        internal Log Log = new();
        internal static string ShopName = Program.Configuration.GetSection("Settings").GetSection("Shop").Get<string>();
        public Form1()
        {
            InitializeComponent();
            Categories = Program.Configuration.GetSection("Upgrades").Get<Dictionary<string, Category>>();
            foreach (var cat in Categories)
            {
                var section = Program.Configuration.GetSection("Upgrades").GetSection(cat.Key).Get<Dictionary<string, Upgrade>>();
                cat.Value.Upgrades = section;
                cat.Value.Name = cat.Key;
                TabPage tab = new(cat.Key);
                upgradeTab.Controls.Add(tab);
                FlowLayoutPanel inner = new();
                inner.FlowDirection = FlowDirection.LeftToRight;
                inner.Parent = tab;
                inner.Dock = DockStyle.Fill;
                inner.BorderStyle = BorderStyle.FixedSingle;
                cat.Value.Page = inner;
                foreach (var upgrade in section)
                {
                    upgrade.Value.Name = upgrade.Key;
                    UpgradeButton button = new(upgrade.Value);
                    button.MouseUp += Upgrade_Click;
                    button.Tag = upgrade.Key;
                    button.cat = cat.Value;
                    button.Text = upgrade.Key;
                    button.Size = new(100, 30);
                    inner.Controls.Add(button);
                }
            }
            nameBox.TextChanged += NameChange;
            vehBox.TextChanged += VehicleChange;
            plateBox.TextChanged += PlateChange;
            isMech.CheckedChanged += IsMechChange;
            resetButton.Click += ResetClick;
            copyButton.Click += CopyButton_Click;
            UpdateLog();
        }

        private void CopyButton_Click(object? sender, EventArgs e)
        {
            Clipboard.SetText(Log.ToString());
        }

        private void Upgrade_Click(object? sender, EventArgs e)
        {
            if (sender is null) throw new ArgumentNullException(nameof(sender));
            UpgradeButton? sndr = sender as UpgradeButton;
            string upgradeKey = sndr.Tag.ToString();
            if (sndr?.cat is null) throw new NullReferenceException(upgradeKey);
            Category cat = sndr.cat;
            var upgrades = cat.Upgrades;
            Upgrade upgrade = upgrades[upgradeKey];
            MouseEventArgs mouseEvent = (MouseEventArgs)e;
            if (mouseEvent.Button == MouseButtons.Right)
            {
                if (Log.Active.ContainsKey(upgrade))
                {
                    Log.Active.Remove(upgrade);
                }
                if (Log.Multi.ContainsKey(upgrade))
                {
                    Log.Multi.Remove(upgrade);
                }
                UpdateLog();
            }
            else if (mouseEvent.Button == MouseButtons.Left)
            {
                if (upgrades[upgradeKey].Options.Count <= 1)
                {
                    Upgrade_Process(sender, e);
                    return;
                }
                UpgradeForm upgradeForm = new UpgradeForm(cat.Upgrades[upgradeKey]);
                upgradeForm.StartPosition = FormStartPosition.CenterParent;
                upgradeForm.ShowDialog();
            }
        }

        internal void Upgrade_Process(object? sender, EventArgs e)
        {
            UpgradeButton btn = (UpgradeButton)sender;
            if (btn.Parent != btn.cat?.Page) ((Form)btn.Parent.Parent).Close();
            if (Log.Active.ContainsKey(btn.upgrade))
            {
                Log.Active[btn.upgrade] = btn.num;
            }
            else
            {
                Log.Active.Add(btn.upgrade, btn.num);
            }
            if (btn.upgrade.Multi)
            {
                Log.Multi.TryAdd(btn.upgrade, new());
                if (!Log.Multi[btn.upgrade].Contains(btn.num)) Log.Multi[btn.upgrade].Add(btn.num);
            }
            //btn.BackColor = Color.Red;
            UpdateLog();
        }

        internal void UpdateLog(object? sender = null, EventArgs? e = null)
        {
            logTextBox.Text = Log.ToString();
        }

        internal void NameChange(object? sender, EventArgs e)
        {
            Log.Name = ((TextBox)sender).Text;
            UpdateLog();
        }
        internal void VehicleChange(object? sender, EventArgs e)
        {
            Log.Vehicle = ((TextBox)sender).Text;
            UpdateLog();
        }
        private void PlateChange(object? sender, EventArgs e)
        {
            Log.Plate = ((TextBox)sender).Text;
            UpdateLog();
        }
        private void IsMechChange(object? sender, EventArgs e)
        {
            Log.Mech = ((CheckBox)sender).Checked;
            UpdateLog();
        }
        private void ResetClick(object? sender, EventArgs e)
        {
            nameBox.Clear();
            vehBox.Clear();
            plateBox.Clear();
            isMech.Checked = false;
            Log = new();
            UpdateLog();
        }
    }
}