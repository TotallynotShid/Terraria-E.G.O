using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShidMod.Content.Items
{ 
	// This is a basic item template.
	// Please see tModLoader's ExampleMod for every other example:
	// https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
	public class TutorialSword : ModItem
	{
        public int attackType = 0; // keeps track of which attack it is
        public int comboExpireTimer = 0; // we want the attack pattern to reset if the weapon is not used for certain period of time
                                         // The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.ShidMod.hjson' file.
        public override void SetDefaults()
		{
            Item.width = 46;
            Item.height = 48;
            Item.value = Item.sellPrice(gold: 2, silver: 50);
            Item.rare = ItemRarityID.Green;

            // Use Properties
            // Note that useTime and useAnimation for this item don't actually affect the behavior because the held projectile handles that. 
            // Each attack takes a different amount of time to execute
            // Conforming to the item useTime and useAnimation makes it much harder to design
            // It does, however, affect the item tooltip, so don't leave it out.
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.Shoot;

            // Weapon Properties
            Item.knockBack = 7;  // The knockback of your sword, this is dynamically adjusted in the projectile code.
            Item.autoReuse = true; // This determines whether the weapon has autoswing
            Item.damage = 62; // The damage of your sword, this is dynamically adjusted in the projectile code.
            Item.DamageType = DamageClass.Melee; // Deals melee damage
            Item.noMelee = true;  // This makes sure the item does not deal damage from the swinging animation
            Item.noUseGraphic = true; // This makes sure the item does not get shown when the player swings his hand

        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}
