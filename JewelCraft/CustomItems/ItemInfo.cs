using Jotunn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelCraft.CustomItems
{
    public class ItemInfo
    {
        public string Name { get; set; }
        public string AssetName { get; set; }
        public string Description { get; set; }
        public string SpritePath { get; set; }
        public CustomStatusEffect StatusEffect { get; set; }
    }
}
