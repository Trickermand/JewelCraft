// JewelCraft
// a Valheim mod skeleton using Jötunn
// 
// File:    JewelCraft.cs
// Project: JewelCraft

using BepInEx;
using BepInEx.Logging;
using JewelCraft.CustomItems;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Apple;
using static Minimap;

namespace JewelCraft
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    //[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class JewelCraft : BaseUnityPlugin
    {
        public const string PluginGUID = "c4478e31-4ee5-456e-80e3-c4e956b5026e";
        public const string PluginName = "JewelCraft";
        public const string PluginVersion = "0.0.1";

        // Asset bundles
        private AssetBundle crude_gold_bar;
        private AssetBundle gold_bar;
        private AssetBundle ball;
        private AssetBundle ring_ruby;
        private AssetBundle jewel_table_asset;

        // Use this class to add your own localization to the game
        // https://valheim-modding.github.io/Jotunn/tutorials/localization.html
        public static CustomLocalization Localization = LocalizationManager.Instance.GetLocalization();

        private void Awake()
        {
            // Jotunn comes with its own Logger class to provide a consistent Log style for all mods using it
            Jotunn.Logger.LogInfo("JewelCraft has landed");

            LoadRecipes();
            LoadCraftingTable();

            // To learn more about Jotunn's features, go to
            // https://valheim-modding.github.io/Jotunn/tutorials/overview.html
        }

        private void Update()
        {
            
        }

        private void OnDestroy()
        {

        }

        private CustomStatusEffect GetStatusEffect_RingRuby()
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

        private void LoadCraftingTable()
        {
            jewel_table_asset = AssetUtils.LoadAssetBundleFromResources("piece_jewel_table");
            Texture2D TestTex = AssetUtils.LoadTexture("JewelCraft/piece_jewel_table_sprite.png");
            Sprite sprite = Sprite.Create(TestTex, new Rect(0f, 0f, TestTex.width, TestTex.height), Vector2.zero);

            PieceConfig pConf = new PieceConfig()
            {
                Description = "A Description!!",
                CraftingStation = "piece_workbench",
                PieceTable = "Hammer",
                Icon = sprite,
                Name = "piece_jewel_table",
                Category = "Misc",
                Requirements = new RequirementConfig[1] { new RequirementConfig("Stone", 1) }
            };

            CustomPiece piece = new CustomPiece(jewel_table_asset, "piece_jewel_table", false, pConf);
            PieceManager.Instance.AddPiece(piece);
        }

        private void LoadRecipes()
        {
            // Load recipes from JSON file
            ItemManager.Instance.AddRecipesFromJson("JewelCraft/recipes.json");

            RingRuby.AddItem(ref ring_ruby);
            CrudeGoldBar.AddItem(ref crude_gold_bar);
            GoldBarJc.AddItem(ref gold_bar);
            CustomItemManager.AddItem(
                new ItemInfo() { Name = "ball", Description = "My ball", SpritePath = "JewelCraft/ball.png" },
                ref ball);
        }
    }
}

