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
        public int num;
        public UpgradeButton(Upgrade up) : base()
        {
            upgrade = up;
        }
    }
}
