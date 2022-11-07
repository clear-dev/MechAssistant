using MechAssistant.Models;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Configuration.Internal;

namespace MechAssistant
{
    public partial class Form1 : Form
    {
        internal static Dictionary<string, Models.Upgrade>? Upgrades;
        internal Log Log = new();
        public Form1()
        {
            InitializeComponent();
            Upgrades = Program.Configuration.GetSection("Upgrades").Get<Dictionary<string, Models.Upgrade>>();
            foreach (var upgrade in Upgrades)
            {
                upgrade.Value.Name = upgrade.Key;
                UpgradeButton button = new(upgrade.Value);
                button.Click += Upgrade_Click;
                button.Tag = upgrade.Key;
                button.Text = upgrade.Key;
                button.Size = new(100, 30);
                UpgradeFlow.Controls.Add(button);
            }
            nameBox.TextChanged += NameChange;
            vehBox.TextChanged += VehicleChange;
            plateBox.TextChanged += PlateChange;
            isMech.CheckedChanged += IsMechChange;
            UpdateLog();
        }

        private void Upgrade_Click(object? sender, EventArgs e)
        {
            if (sender is null) throw new ArgumentNullException(nameof(sender));
            string upgradeKey = ((UpgradeButton)sender).Tag.ToString();
            if (Upgrades[upgradeKey] is null) throw new NullReferenceException(upgradeKey);
            if (Upgrades[upgradeKey].Options.Count <= 1)
            {
                Upgrade_Process(sender, e);
                return;
            }
            UpgradeForm upgradeForm = new UpgradeForm(upgradeKey);
            upgradeForm.StartPosition = FormStartPosition.CenterParent;
            upgradeForm.ShowDialog();
        }

        internal void Upgrade_Process(object? sender, EventArgs e)
        {
            UpgradeButton btn = (UpgradeButton)sender;
            if (Log.Active.ContainsKey(btn.upgrade))
            {
                Log.Active[btn.upgrade] = btn.num;
            }
            else
            {
                Log.Active.TryAdd(btn.upgrade, btn.num);
            }
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
    }
}