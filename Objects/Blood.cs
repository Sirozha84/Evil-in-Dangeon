using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SGen;

namespace Evil_in_Dangeon
{
    class Blood : Box
    {
        public static Texture2D Texture;

        public Blood(int x, int y) : base(x - 2, y - 2, 4, 4, 0, 0, false, false, true, 0.1f, 0, 0)
        {
            Impuls(RND.Next(360), RND.Next(10));
        }

        public override void Collision(Box box) { }

        public override void Draw()
        {
            Draw(Texture);
        }

        public override void Trigger() { }

        public override void Update()
        {
            Physics(true);
        }
    }
}
