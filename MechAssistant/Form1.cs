using MechAssistant.Models;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Configuration.Internal;

namespace MechAssistant
{
    public partial class Form1 : Form
    {
        internal static Dictionary<string, Models.Upgrade>? Upgrades;
        internal Log Log;
        public Form1()
        {
            InitializeComponent();
            Upgrades = Program.Configuration.GetSection("Upgrades").Get<Dictionary<string, Models.Upgrade>>();
            foreach (var upgrade in Upgrades)
            {
                Button button = new();
                button.Click += Upgrade_Click;
                button.Tag = upgrade.Key;
                button.Text = upgrade.Key;
                button.Size = new(100, 30);
                UpgradeFlow.Controls.Add(button);
            }
        }

        private void Upgrade_Click(object? sender, EventArgs e)
        {
            if (sender is null) throw new ArgumentNullException(nameof(sender));
            string upgradeKey = ((Button)sender).Tag.ToString();
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

        }
    }
}