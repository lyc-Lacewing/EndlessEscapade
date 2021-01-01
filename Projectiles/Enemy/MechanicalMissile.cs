using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace EEMod.Projectiles.Enemy
{
    public class MechanicalMissile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Missile");
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 8;
            projectile.alpha = 0;
            projectile.timeLeft = 1200;
            projectile.penetrate = 1;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.scale = 1f;
            projectile.aiStyle = -1;
            projectile.spriteDirection = -1;
        }

        public override void AI()
        {
            Vector2 closestPlayer = new Vector2();
            for (int i = 0; i < Main.player.Length; i++)
            {
                if (Vector2.DistanceSquared(Main.player[i].Center, projectile.Center) <= Vector2.DistanceSquared(closestPlayer, projectile.Center))
                {
                    closestPlayer = Main.player[i].Center;
                }
            }

            projectile.velocity = Vector2.Normalize(closestPlayer - projectile.Center) * 10;
            projectile.rotation = projectile.velocity.ToRotation();

            if (++projectile.frameCounter >= 4)
            {
                projectile.frameCounter = 0;
                projectile.frame = ++projectile.frame % Main.projFrames[projectile.type];
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 20; i++)
            {
                int dust = Dust.NewDust(projectile.position, 0, 0, 6);
                Main.dust[dust].velocity = projectile.velocity + new Vector2(Main.rand.NextFloat(-1, 2), Main.rand.NextFloat(-1, 2));
            }
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            projectile.Kill();
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Main.spriteBatch.Draw(ModContent.GetInstance<EEMod>().GetTexture("Projectiles/Enemy/MechanicalMissileGlow"), projectile.Center - Main.screenPosition, projectile.getRect(), Color.White, projectile.rotation, projectile.getRect().Size() / 2, projectile.scale, projectile.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }
    }
}