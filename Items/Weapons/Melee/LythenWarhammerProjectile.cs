using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using EEMod.Prim;
using EEMod.Extensions;

namespace EEMod.Items.Weapons.Melee
{
    public class LythenWarhammerProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tidebreaker");
            Main.projFrames[projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            projectile.width = 54;
            projectile.height = 60;
            projectile.aiStyle = -1;
            projectile.penetrate = -1;
            projectile.scale = 1f;

            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.damage = 20;
            projectile.knockBack = 3.5f;
        }

        double radians = 0;
        int flickerTime = 0;
        float alphaCounter = 0;
        int chargeTime = 90;
        //ai[0] = charge
        //ai[1] = Whether or not thrown
        int height = 60;
        int width = 54;
        public override void AI()
        {
            alphaCounter += 0.08f;
            Player player = Main.player[projectile.owner];
            EEMod.MainParticles.SetSpawningModules(new SpawnRandomly(0.4f));
            if (projectile.ai[1] == 0)
            {
                projectile.scale = MathHelper.Clamp(projectile.ai[0] / 10, 0, 1);
                if (player.direction == 1)
                {
                    radians += (double)((projectile.ai[0] + 10) / 200);
                }
                else
                {
                    radians -= (double)((projectile.ai[0] + 10) / 200);
                }
                if (radians > 6.28)
                {
                    radians -= 6.28;
                }
                if (radians < -6.28)
                {
                    radians += 6.28;
                }
                player.itemAnimation -= (int)((projectile.ai[0] + 50) / 6);

                while (player.itemAnimation < 3)
                {
                    Main.PlaySound(SoundID.Item1, projectile.Center);
                    player.itemAnimation += 320;
                }
                player.itemTime = player.itemAnimation;
                projectile.velocity = Vector2.Zero;

                if (projectile.ai[0] < chargeTime)
                {
                    projectile.ai[0]++;
                    if (projectile.ai[0] == chargeTime)
                    {
                        Main.PlaySound(SoundID.NPCDeath7, projectile.Center);
                    }
                }
                else
                {
                    EEMod.MainParticles.SetSpawningModules(new SpawnRandomly(0.1f));
                    EEMod.MainParticles.SpawnParticles(projectile.Center, new Vector2(Main.rand.NextFloat(-1f, 1f), Main.rand.NextFloat(-1f, 1f)) * 2, 2, Color.Gold, new SlowDown(0.99f), new ZigzagMotion(10, 1.5f), new AfterImageTrail(0.99f));
                }
                Vector2 direction = Main.MouseWorld - player.position;
                direction.Normalize();
                double throwingAngle = direction.ToRotation() + 3.14;
                if (player.direction != 1)
                {
                    throwingAngle -= 6.28;
                }
                if (!player.channel && Math.Abs(radians - throwingAngle) < 1)
                {
                    projectile.ai[1] = 1;
                    player.itemTime = 2;
                    player.itemAnimation = 2;

                    projectile.tileCollide = true;
                    projectile.timeLeft = 500;
                    projectile.position = player.position;

                    direction *= 30;
                    projectile.velocity = direction;
                }
                projectile.position.Y = player.Center.Y - (int)(Math.Sin(radians * 0.96) * 40) - (projectile.height / 2);
                projectile.position.X = player.Center.X - (int)(Math.Cos(radians * 0.96) * 40) - (projectile.width / 2);
            }



            else if (projectile.ai[1] == 1)
            {
                if (projectile.ai[0] < chargeTime)
                {
                    projectile.active = false;
                }
                else
                {
                    EEMod.MainParticles.SetSpawningModules(new SpawnRandomly(0.4f));
                    EEMod.MainParticles.SpawnParticles(projectile.Center + (projectile.velocity * 5), new Vector2(Main.rand.NextFloat(-1f, 1f), Main.rand.NextFloat(-1f, 1f)) * 2, 2, Color.Gold, new SlowDown(0.99f), new ZigzagMotion(10, 1.5f), new AfterImageTrail(0.99f));
                    projectile.rotation = projectile.velocity.ToRotation() + 0.78f;
                }
                if (projectile.timeLeft == 450)
                {
                    projectile.ai[1] = 2;
                }
            }
            else
            {
                projectile.tileCollide = false;
                projectile.rotation -= 0.5f;
                Vector2 direction = player.position - projectile.position;
                if (direction.Length() < 20 || player.statLife < 1)
                {
                    Main.LocalPlayer.GetModPlayer<EEPlayer>().TurnCameraFixationsOff();
                    projectile.active = false;
                }
                direction.Normalize();
                direction *= 20;
                projectile.velocity = direction;
                if (projectile.timeLeft == 170)
                {
                    Main.LocalPlayer.GetModPlayer<EEPlayer>().TurnCameraFixationsOff();
                }
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (projectile.ai[1] == 0)
            {
                Color color = lightColor;
                Main.spriteBatch.Draw(Main.projectileTexture[projectile.type], Main.player[projectile.owner].Center - Main.screenPosition, new Rectangle(0, 0, width, height), color, (float)radians + 3.9f, new Vector2(0, height), projectile.scale, SpriteEffects.None, 0);
                if (projectile.ai[0] >= chargeTime && projectile.ai[1] == 0)
                {
                    Main.spriteBatch.Draw(Main.projectileTexture[projectile.type], Main.player[projectile.owner].Center - Main.screenPosition, new Rectangle(0, height * 2, width, height), Color.White * 0.9f, (float)radians + 3.9f, new Vector2(0, height), projectile.scale, SpriteEffects.None, 1);

                    if (flickerTime < 16)
                    {
                        flickerTime++;
                        color = Color.White;
                        float flickerTime2 = (float)(flickerTime / 20f);
                        float alpha = 1.5f - (((flickerTime2 * flickerTime2) / 2) + (2f * flickerTime2));
                        if (alpha < 0)
                        {
                            alpha = 0;
                        }
                        Main.spriteBatch.Draw(Main.projectileTexture[projectile.type], Main.player[projectile.owner].Center - Main.screenPosition, new Rectangle(0, height, width, height), color * alpha, (float)radians + 3.9f, new Vector2(0, height), projectile.scale, SpriteEffects.None, 1);
                    }
                }
                return false;
            }
            return true;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (projectile.ai[0] >= chargeTime)
            {
                float sineAdd = (float)Math.Sin(alphaCounter) + 2.5f;

                Main.spriteBatch.End();
                Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive, null, null, null, null, Main.GameViewMatrix.TransformationMatrix);

                Texture2D tex = ModContent.GetTexture("EEMod/Textures/SmoothFadeOut");

                Main.spriteBatch.Draw(tex, projectile.Center.ForDraw(), tex.Bounds, Color.Gold * sineAdd * 0.3f, 0, new Vector2(31, 23), 0.25f * (sineAdd + 1) * 2, SpriteEffects.None, 0f);

                Main.spriteBatch.End();
                Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Main.GameViewMatrix.TransformationMatrix);
            }
            if (projectile.ai[1] != 0)
            {
                Main.spriteBatch.Draw(Main.projectileTexture[projectile.type], new Rectangle((int)(projectile.Center.X - Main.screenPosition.X), (int)(projectile.Center.Y - Main.screenPosition.Y), 54, 60), new Rectangle(0, height * 2, width, height), Color.White, projectile.rotation, new Vector2(27, 30), SpriteEffects.None, 0);
            }
        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (projectile.ai[1] == 1 && projectile.ai[0] >= chargeTime)
            {
                DoTheThing(projectile.position);
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.ai[0] >= chargeTime)
                DoTheThing(projectile.position + (projectile.velocity * 2));
            return false;
        }

        private void DoTheThing(Vector2 pos)
        {
            Main.LocalPlayer.GetModPlayer<EEPlayer>().FixateCameraOn(projectile.Center, 8f, true, false, 8);
            projectile.timeLeft = 200;
            if (projectile.ai[1] == 1)
            {
                for (double i = 0; i < 6.28; i += Main.rand.NextFloat(1f, 2f))
                {
                    int lightningproj = Projectile.NewProjectile(pos, new Vector2((float)Math.Sin(i), (float)Math.Cos(i)) * 2.5f, ModContent.ProjectileType<AxeLightning>(), projectile.damage, projectile.knockBack, projectile.owner);
                    if (Main.netMode != NetmodeID.Server)
                    {
                        EEMod.primitives.CreateTrail(new AxeLightningPrimTrail(Main.projectile[lightningproj]));
                    }
                }
                projectile.ai[1] = 2;
            }
            Main.PlaySound(SoundID.Item70, projectile.Center);
        }
    }
}