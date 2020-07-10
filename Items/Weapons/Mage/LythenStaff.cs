using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using EEMod.Items.Placeables.Ores;
using EEMod.Projectiles.Mage;

namespace EEMod.Items.Weapons.Mage
{
    public class LythenStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lythen Staff");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 22;
            item.width = 32;
            item.height = 32;
            item.useTime = 20;
            item.useAnimation = 20;
            item.knockBack = 0;
            item.rare = ItemRarityID.Green;
            item.autoReuse = true;
            item.crit = 3;
            item.noMelee = true;
            item.magic = true;
            item.shoot = ModContent.ProjectileType<LythenStaffProjectile>();
            item.shootSpeed = 16f;
            item.mana = 5;
            item.UseSound = SoundID.Item8;
            item.useStyle = ItemUseStyleID.HoldingOut;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-1, -4);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<LythenBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
