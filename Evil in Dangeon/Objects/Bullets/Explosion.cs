using System;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Evil_in_Dangeon
{
    class Explosion : Bullet
    {
        public static Texture2D Texture;
        public static SoundEffect Sound;
        int timer;
        public Explosion(int x, int y, bool Enemy) :
            base(x, y, 80, 80, 1, false, 5, Enemy)
        {
        }

        protected override void DrawBullet()
        {
            Draw(Texture);
        }

        public override void Update()
        {
            timer++;
            if (timer > 3)
            {
                timer = 0;
                AnimationFrame++;
                if (AnimationFrame > 7) Destroy();
            }
        }
    }
}
