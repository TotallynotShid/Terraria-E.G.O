using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.Audio;
using static System.Net.Mime.MediaTypeNames;
using rail;


namespace ShidMod.Content.Projectiles
{
    public class TheLiving : ModProjectile
    {
        private Player Owner => Main.player[Projectile.owner];
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Bullet);
            AIType = ProjectileID.Bullet;
        }

        public override void OnSpawn(IEntitySource source)
        {
            Projectile.NewProjectile(source, Owner.position, Vector2.Zero, ModContent.ProjectileType<Ripple>(), 0, 0);
        }
        public override void AI()
        {
            Projectile.height = 10;
            Projectile.width = 10;
        }
    }
}
