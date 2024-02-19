using MechAssistant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MechAssistant
{
    public partial class UpgradeForm : Form
    {
        internal UpgradeForm(Upgrade upgrade)
        {
            InitializeComponent();
            Text = upgrade.Name;
            foreach (var item in upgrade.Options)
            {
                UpgradeButton button = new(upgrade);
                button.num = item.Key;
                button.Tag = upgrade.Name;
                button.MouseUp += ((Form1)Form1.ActiveForm).Upgrade_Process;
                button.Width = ClientSize.Width - 10;
                button.Height = 30;
                button.Left = ClientSize.Width - button.Width / 2;
                button.Top = ClientSize.Height - button.Height / 2;
                button.Text = $"{upgrade.Name} {item.Key}";
                flowLayout.Controls.Add(button);
                button.Anchor = AnchorStyles.None;
            }
        }
    }
}
