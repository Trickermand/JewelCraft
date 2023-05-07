using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Minimap;
using static Mono.Security.X509.X520;

namespace JewelCraft.CustomItems
{
    public static class CrudeGoldBar
    {
        public static void AddItem(ref AssetBundle assetToSet)
        {
            ItemInfo itemInfo = new ItemInfo()
            {
                AssetName = "crude_gold_bar",
                Description = "My crude gold bar description",
                SpritePath = "JewelCraft/crude_gold_bar_sprite.png"
            };

            CustomItemManager.AddItem(itemInfo, ref assetToSet);
        }
    }
}
