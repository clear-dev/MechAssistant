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
        public Dictionary<Upgrade, string> Active = new();
        public Dictionary<Upgrade, List<string>> Multi = new();
        public int Total = 0;
        public bool Mech = false;

        public override string ToString()
        {
            return 
$@"```Customer Name: {Name} {(Mech ? "[MECH]" : "")}
Vehicle | [Make/Model]: {Vehicle}
Plate: {Plate}
Upgrades Purchased: {FormatUpgrades()}
Price Charged: ${string.Format("{0:n0}", TotalPrice())}
SHOP: {Form1.ShopName}```
";
        }

        public int TotalPrice()
        {
            Total = 0;
            foreach (var item in Active)
            {
                Total += ((item.Key.Options[item.Value.ToString()]) + (Mech == false ? item.Key.Markup : 0)) * (Multi.ContainsKey(item.Key) ? Multi[item.Key].Count : 1);
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
                string prefix = "";
                if (Multi.ContainsKey(item.Key))
                {
                    for (int o = 0; o < Multi[item.Key].Count; o++)
                    {
                        var mult = Multi[item.Key][o];
                        prefix += $"{mult}{(o + 1 == Multi[item.Key].Count ? " " : "/")}";
                    }
                }
                ret += $"{prefix}{item.Key.Name}{suffix}";
            }
            return ret;
        }
    }
}
