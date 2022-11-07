using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechAssistant.Models
{
    internal class Log
    {
        public string Name = "";
        public string Vehicle = "";
        public string Plate = "";
        public Dictionary<Upgrade, int> Active = new();
        public int Total = 0;
        public bool Mech = false;

        public override string ToString()
        {
            return 
$@"```Customer Name: {Name}
Vehicle | [Make/Model]: {Vehicle}
Plate: {Plate}
Upgrades Purchased: {FormatUpgrades()}
Price Charged: ${string.Format("{0:n0}", TotalPrice())}
SHOP: Tuners```
";
        }

        public int TotalPrice()
        {
            Total = 0;
            foreach (var item in Active)
            {
                Total += item.Key.Options[item.Value] + (Mech == false ? item.Key.Markup : 0);
            }
            return Total;
        }

        public string FormatUpgrades()
        {
            string ret = "";
            int i = 0;
            foreach (var item in Active)
            {
                i++;
                string suffix = ", ";
                if (i == Active.Count) suffix = "";
                ret += $"{item.Key.Name}{suffix}";
            }
            return ret;
        }
    }
}
