using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Minimap;
using static Mono.Security.X509.X520;

namespace JewelCraft.CustomItems
{
    public static class GoldBarJc
    {
        public static void AddItem(ref AssetBundle assetToSet)
        {
            ItemInfo itemInfo = new ItemInfo()
            {
                Name = "Gold bar",
                AssetName = "gold_bar_jc",
                Description = "My gold bar description",
                SpritePath = "JewelCraft/gold_bar_sprite.png"
            };

            CustomItemManager.AddItem(itemInfo, ref assetToSet);
        }
    }
}
