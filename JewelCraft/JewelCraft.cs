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

            LoadItems();
            LoadCraftingTable();
            ItemManager.Instance.AddRecipesFromJson("JewelCraft/recipes.json");

            // To learn more about Jotunn's features, go to
            // https://valheim-modding.github.io/Jotunn/tutorials/overview.html
        }

        private void Update()
        {
            
        }

        private void OnDestroy()
        {

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

        private void LoadItems()
        {
            // Load recipes from JSON file

            RingRuby.AddItem(ref ring_ruby);
            CrudeGoldBar.AddItem(ref crude_gold_bar);
            GoldBarJc.AddItem(ref gold_bar);
            CustomItemManager.AddItem(
                new ItemInfo() { Name = "ball", Description = "My ball", SpritePath = "JewelCraft/ball.png" },
                ref ball);
        }
    }
}

