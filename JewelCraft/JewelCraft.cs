// JewelCraft
// a Valheim mod skeleton using Jötunn
// 
// File:    JewelCraft.cs
// Project: JewelCraft

using BepInEx;
using BepInEx.Logging;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;
using UnityEngine.Apple;

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
        private AssetBundle agate;

        // Use this class to add your own localization to the game
        // https://valheim-modding.github.io/Jotunn/tutorials/localization.html
        public static CustomLocalization Localization = LocalizationManager.Instance.GetLocalization();

        private void Awake()
        {
            // Jotunn comes with its own Logger class to provide a consistent Log style for all mods using it
            Jotunn.Logger.LogInfo("JewelCraft has landed");


            LoadRecipes();
            
            // To learn more about Jotunn's features, go to
            // https://valheim-modding.github.io/Jotunn/tutorials/overview.html
        }

        private void Update()
        {
            
        }

        private void OnDestroy()
        {

        }

        private void LoadRecipes()
        {
            // Create a custom recipe with a RecipeConfig
            RecipeConfig meatConfig = new RecipeConfig();
            meatConfig.Item = "CookedMeat"; // Name of the item prefab to be crafted
            meatConfig.AddRequirement(new RequirementConfig("Stone", 3)); // Resources and amount needed for it to be crafted
            meatConfig.AddRequirement(new RequirementConfig("Wood", 1));
            ItemManager.Instance.AddRecipe(new CustomRecipe(meatConfig));

            // Load recipes from JSON file
            ItemManager.Instance.AddRecipesFromJson("JewelCraft/recipes.json");


            string itemName = "agate";
            agate = AssetUtils.LoadAssetBundleFromResources(itemName);

            Logger.LogInfo("Loaded asset bundles");

            Texture2D TestTex = AssetUtils.LoadTexture("JewelCraft/agate_sprite.png");
            Sprite TestSprite = Sprite.Create(TestTex, new Rect(0f, 0f, TestTex.width, TestTex.height), Vector2.zero);

            Logger.LogInfo("Created sprites");

            ItemConfig itemConfAgate = new ItemConfig()
            {
                Amount = 2,
                CraftingStation = null,
                Description = "My Agate",
                Icons = new Sprite[1] { TestSprite },
                Name = itemName,
                Requirements = new RequirementConfig[1]
                {
                    new RequirementConfig() { Amount = 1, Item = "Stone" }
                }
            };

            Logger.LogInfo("Set up configs");

            CustomItem itemAgate = new CustomItem(agate, itemName, false, itemConfAgate);

            Logger.LogInfo("Adding item " + itemAgate.ToString());
            ItemManager.Instance.AddItem(itemAgate);

        }
    }
}

