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

namespace JewelCraft
{
    public class MyExamples
    {

        private AssetBundle cube;
        private void LoadCube()
        {

            cube = AssetUtils.LoadAssetBundleFromResources("cube");
            Texture2D TestTex = AssetUtils.LoadTexture("JewelCraft/piece_jewel_table_sprite.png");
            Sprite sprite = Sprite.Create(TestTex, new Rect(0f, 0f, TestTex.width, TestTex.height), Vector2.zero);

            PieceConfig pConf = new PieceConfig()
            {
                Description = "cube",
                CraftingStation = "piece_workbench",
                PieceTable = "Hammer",
                Icon = sprite,
                Name = "cube",
                Category = "Misc",
                Requirements = new RequirementConfig[1] { new RequirementConfig("Stone", 1) }
            };


            CustomPiece piece = new CustomPiece(cube, "cube", false, pConf);
            PieceManager.Instance.AddPiece(piece);
        }

        private void LoadRecipeManually()
        {
            // Create a custom recipe with a RecipeConfig
            RecipeConfig meatConfig = new RecipeConfig();
            meatConfig.Item = "CookedMeat"; // Name of the item prefab to be crafted
            meatConfig.AddRequirement(new RequirementConfig("Stone", 3)); // Resources and amount needed for it to be crafted
            meatConfig.AddRequirement(new RequirementConfig("Wood", 1));
            ItemManager.Instance.AddRecipe(new CustomRecipe(meatConfig));
        }
    }
}
