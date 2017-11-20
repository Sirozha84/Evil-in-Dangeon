using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SGen;

namespace Evil_in_Dangeon
{
    class Coin : Box
    {
        public static Texture2D Texture;
        public static SoundEffect Sound;
        public int Nominal;
        bool Static;
        int timer;

        public Coin(int X, int Y, int Nominal, bool Static) :
            base(X - 10, Y - 10, 20, 20, 0, 0, false, true, true, 0.5f, 0.5f, 0)
        {
            this.Static = Static;
            this.Nominal = Nominal;
            AnimationFrame = RND.Next(0, 3);
            AnimationSet = Nominal;
        }

        public override void Collision(Box box) { }

        public override void Draw()
        {
            Draw(Texture);
            timer++;
            if (timer > 4)
            {
                timer = 0;
                AnimationFrame++;
                if (AnimationFrame > 3) AnimationFrame = 0;
            }
        }

        public override void Trigger() { }

        public override void Update()
        {
            if (!Static) Physics(true);
        }

        public int Take()
        {
            Sound.Play();
            World.NewObject(new Flash((int)Position.X, (int)Position.Y));
            Destroy();
            if (Nominal == 0) return 1;
            if (Nominal == 1) return 3;
            return 10;
        }
    }
}
