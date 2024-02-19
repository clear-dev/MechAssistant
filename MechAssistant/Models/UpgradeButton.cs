using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechAssistant.Models
{
    internal class UpgradeButton : Button
    {
        public Upgrade upgrade;
        public string num = "1";
        public Category cat;
        public UpgradeButton(Upgrade up) : base()
        {
            upgrade = up;
        }
    }
}
