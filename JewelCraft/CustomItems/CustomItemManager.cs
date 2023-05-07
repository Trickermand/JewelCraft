using BepInEx;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Minimap;

namespace JewelCraft.CustomItems
{
    public static class CustomItemManager
    {
        public static void AddItem(ItemInfo itemInfo, ref AssetBundle assetToSet)
        {
            if (itemInfo.Name is null)
                throw new ArgumentNullException(nameof(itemInfo.Name), $"Set '{nameof(itemInfo.Name)}' before calling this method.");
            if (itemInfo.Description is null)
                throw new ArgumentNullException(nameof(itemInfo.Description), $"Set '{nameof(itemInfo.Description)}' before calling this method.");
            if (itemInfo.SpritePath is null)
                throw new ArgumentNullException(nameof(itemInfo.SpritePath), $"Set '{nameof(itemInfo.SpritePath)}' before calling this method.");


            Jotunn.Logger.LogInfo($"Adding item '{itemInfo.Name}', " +
                $"StatusEffect '{itemInfo.StatusEffect?.StatusEffect?.name ?? "nothing"}'," +
                $"itemDesc '{itemInfo.Description}'," +
                $"SpritePath '{itemInfo.SpritePath}'");

            assetToSet = AssetUtils.LoadAssetBundleFromResources(itemInfo.Name);
            Texture2D TestTex = AssetUtils.LoadTexture(itemInfo.SpritePath);
            Sprite TestSprite = Sprite.Create(TestTex, new Rect(0f, 0f, TestTex.width, TestTex.height), Vector2.zero);

            ItemConfig itemConfig = new ItemConfig()
            {
                Description = itemInfo.Description,
                CraftingStation = null,
                Icons = new Sprite[1] { TestSprite },
                Name = itemInfo.Name
            };

            CustomItem item = new CustomItem(assetToSet, itemInfo.Name, false, itemConfig);
            if (!(itemInfo.StatusEffect is null))
                item.ItemDrop.m_itemData.m_shared.m_equipStatusEffect = itemInfo.StatusEffect.StatusEffect;

            ItemManager.Instance.AddItem(item);
        }

    }
}
