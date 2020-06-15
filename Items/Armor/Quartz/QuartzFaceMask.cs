using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EEMod.Items.Materials;

namespace EEMod.Items.Armor.Quartz
{
    [AutoloadEquip(EquipType.Head)]
    public class QuartzFaceMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Quartz Facemask");
            Tooltip.SetDefault("4 defense\n5% increased ranged damage\n4% increased ranged critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 24;
            item.value = Item.buyPrice(0, 12, 35, 0);
            item.rare = ItemRarityID.Pink;
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<QuartzChestplate>() && legs.type == ModContent.ItemType<QuartzLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Criticals inflict cursed inferno for 2 seconds";
            player.GetModPlayer<EEPlayer>().isQuartzRangedOn = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.statDefense += 4;
            player.rangedDamage *= 1.05f;
            player.rangedCrit += 4;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<QuartzGem>(), 7);
            recipe.AddIngredient(ItemID.PlatinumHelmet, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<QuartzGem>(), 7);
            recipe.AddIngredient(ItemID.GoldHelmet, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
