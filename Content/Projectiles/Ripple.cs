using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Microsoft.Xna.Framework;

namespace ShidMod.Content.Projectiles
{
    public class Ripple : ModProjectile
    {
        private Player Owner => Main.player[Projectile.owner];
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 7;
        }
        public override void SetDefaults()
        {
            Projectile.aiStyle = -1;
            Projectile.penetrate = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.friendly = true;

        }
        public override void OnSpawn(IEntitySource source)
        {
            Lighting.AddLight(Projectile.position, 1, 0, 0);
            Projectile.rotation = Owner.itemRotation;
            if (Owner.direction == 1)
            {
                Projectile.Center = Owner.Center + new Vector2((Owner.HeldItem.width) * Owner.direction, -50).RotatedBy(
                Owner.itemRotation - MathHelper.ToRadians(Projectile.ai[1] * Owner.direction));
            }
            if (Owner.direction == -1)
            {
                Projectile.Center = Owner.Center + new Vector2((Owner.HeldItem.width) * Owner.direction + -30, -50).RotatedBy(
                Owner.itemRotation - MathHelper.ToRadians(Projectile.ai[1] * Owner.direction));
            }
            Projectile.spriteDirection = Owner.direction;
        }
        public override void AI()
        {
            if (++Projectile.frameCounter >= 3)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.alpha = 255;
                }
            }
        }


    }
}
