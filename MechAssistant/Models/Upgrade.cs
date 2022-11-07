using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechAssistant.Models
{
    internal class Upgrade
    {
        public string Name { get; set; }
        public int Markup { get; set; }
        public bool Multi { get; set; } = false;
        public Dictionary<string, int> Options { get; set; } = new();
    }
}
