using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SGen;

namespace Evil_in_Dangeon
{
    class Bonus : Box
    {
        public static Texture2D Texture;
        int delta = 0;
        int timer = 0;

        public Bonus(int x, int y, int type) : base(x , y, 80, 28)
        {
            AnimationSet = type;
        }

        public override void Collision(Box box) { }

        public override void Draw()
        {
            if (delta < 50) Draw(Texture);
            else
            {
                timer++;
                if (timer < 2) Draw(Texture);
                if (timer > 4) timer = 0;
            }
        }

        public override void Trigger() { }

        public override void Update()
        {
            delta++;
            if (delta < 40) Position.Y -= 3;
            if (delta > 80) Destroy();
        }
    }
}
