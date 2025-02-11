using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using System.Security.Cryptography.X509Certificates;
using Steamworks;
using Terraria;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using ShidMod.Content.Projectiles;


namespace ShidMod.Content.Items
{
    public class Butterfly : ModItem
    {
        public override void SetDefaults()
        {
            // Visual properties
            Item.width = 60;
            Item.height = 20;
            Item.scale = 1.05f;
            Item.useStyle = ItemUseStyleID.Shoot; // Use style for guns
            Item.rare = ItemRarityID.Purple;

            // Combat properties
            Item.damage = 20; // Gun damage + bullet damage = final damage
            Item.DamageType = DamageClass.Ranged;
            Item.useTime = 5; // Delay between shots.
            Item.useAnimation = 5; // How long shoot animation lasts in ticks.
            Item.knockBack = 4.5f; // Gun knockback + bullet knockback = final knockback
            Item.autoReuse = true;

            // Other properties
            Item.value = 10000;

            // Gun properties
            Item.noMelee = true; // Item not dealing damage while held, we don’t hit mobs in the head with a gun
            Item.shoot = ModContent.ProjectileType<Projectiles.TheLiving>(); // What kind of projectile the gun fires, does not mean anything here because it is replaced by ammo
            Item.shootSpeed = 60f; // Speed of a projectile. Mainly measured by eye
            Item.useAmmo = AmmoID.Bullet; // What ammo gun uses
            Item.shootSpeed = 1000f;
            
        }

        public override Vector2? HoldoutOffset() => new Vector2(-8f, 0f); 
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            string shot1 = $"ShidMod/Content/Sounds/butterfly_1";
            string shot2 = $"ShidMod/Content/Sounds/butterfly_2";
            string shot3 = $"ShidMod/Content/Sounds/butterfly_3";
            string shot4 = $"ShidMod/Content/Sounds/butterfly_4";
            string shot5 = $"ShidMod/Content/Sounds/butterfly_5";

            Dictionary<int, object> soundDict = new Dictionary<int, object>
            {
                {1, $"ShidMod/Content/Sounds/butterfly_1" },
                {2,  $"ShidMod/Content/Sounds/butterfly_2" },
                {3, $"ShidMod/Content/Sounds/butterfly_3" },
                {4, $"ShidMod/Content/Sounds/butterfly_4" },
                {5, $"ShidMod/Content/Sounds/butterfly_5" }
            };




            int randomKey = Main.rand.Next(1, 6);
            SoundEngine.PlaySound(new SoundStyle(soundDict[randomKey].ToString()) { Volume = 0.5f }, player.Center);

            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<Projectiles.TheLiving>(), damage, knockback, player.whoAmI);

            return false;
        }
    }
}
