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

        public Bonus(int x, int y, int type) : base(x , y, 80, 20)
        {
            AnimationSet = type;
        }

        public override void Collision(Box box)
        {
        }

        public override void Draw()
        {
            Draw(Texture);
        }

        public override void Trigger()
        {
        }

        public override void Update()
        {
            delta++;
            if (delta < 50) Position.Y -= 2;
            if (delta > 100) Destroy();
        }
    }
}
