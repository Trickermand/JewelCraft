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


            string itemName = "Splatt";
            Sprite sprite = Sprite.Create(new Texture2D(100, 100), new Rect(0f, 0f, 100, 100), new Vector2(50f, 50f));
            ItemConfig itemConf = new ItemConfig()
            {
                Amount = 4,
                CraftingStation = null,
                Description = "This item is significantly better than a Klopper.",
                Icons = new Sprite[1] { sprite },
                Name= itemName,
                Requirements = new RequirementConfig[2]
                {
                    new RequirementConfig() { Amount = 1, Item = "Stone" },
                    new RequirementConfig() { Amount = 1, Item = "Wood" }
                }
            };
            CustomItem item = new CustomItem(itemName, false, itemConf);
            ItemManager.Instance.AddItem(item);
        }
    }
}

