using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SGen;

namespace Evil_in_Dangeon
{
    class Flash : Box
    {
        public static Texture2D Texture;
        int timer = 0;

        public Flash(int x, int y) : base(x, y, 20, 20)
        {

        }

        public override void Collision(Box box)
        {
        }

        public override void Draw()
        {
            Draw(Texture);
            timer++;
            if (timer > 4)
            {
                timer = 0;
                AnimationFrame++;
                if (AnimationFrame > 3) Destroy();
            }
        }

        public override void Trigger()
        {
        }

        public override void Update()
        {

        }
    }
}
