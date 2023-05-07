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
    public static class RingRuby
    {
        public static void AddItem(ref AssetBundle assetToSet)
        {
            ItemInfo itemInfo = new ItemInfo()
            {
                AssetName = "ring_ruby",
                Description = "My ruby ring description",
                SpritePath = "JewelCraft/ring_ruby_sprite.png",
                StatusEffect = GetStatusEffect_RingRuby()
            };

            CustomItemManager.AddItem(itemInfo, ref assetToSet);
        }

        private static CustomStatusEffect GetStatusEffect_RingRuby()
        {
            float regen = 1.1f;
            StatusEffect effect = ScriptableObject.CreateInstance<StatusEffect>();
            effect.name = "ring_ruby_statusEffect";
            effect.ModifyHealthRegen(ref regen);
            effect.m_name = "ring_ruby_statusEffect_m";
            effect.m_icon = AssetUtils.LoadSpriteFromFile("JotunnModExample/Assets/ring_ruby_sprite.png");
            effect.m_startMessageType = MessageHud.MessageType.Center;
            effect.m_startMessage = "You feel healthy";
            effect.m_stopMessageType = MessageHud.MessageType.Center;
            effect.m_stopMessage = "You feel fat";

            CustomStatusEffect statusEffect = new CustomStatusEffect(effect, fixReference: false);
            ItemManager.Instance.AddStatusEffect(statusEffect);
            return statusEffect;
        }
    }
}
