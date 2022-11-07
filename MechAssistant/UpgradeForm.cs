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
        public UpgradeForm(string upgrade)
        {
            InitializeComponent();
            Text = upgrade;
            Models.Upgrade up = Form1.Upgrades[upgrade];
            for (int i = 0; i < up.Options.Count; i++)
            {
                UpgradeButton button = new(up);
                button.num = i;
                button.Tag = upgrade;
                button.Click += ((Form1)Form1.ActiveForm).Upgrade_Process;
                button.Width = ClientSize.Width - 10;
                button.Height = 30;
                button.Left = ClientSize.Width - button.Width / 2;
                button.Top = ClientSize.Height - button.Height / 2;
                button.Text = $"{upgrade} {i+1}";
                flowLayout.Controls.Add(button);
                button.Anchor = AnchorStyles.None;
            }
        }
    }
}
