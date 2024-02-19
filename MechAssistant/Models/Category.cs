using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MechAssistant.Models
{
    internal class Category
    {
        public static List<Category> categories = new();
        public string Name { get; set; }
        public Dictionary<string, Upgrade> Upgrades { get; set; }
        public FlowLayoutPanel Page;
    }
}
