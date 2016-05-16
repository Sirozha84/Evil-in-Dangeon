using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SGen;

namespace Evil_in_Dangeon
{
    class Hero : Box
    {
        public static Texture2D Texture;

        public Hero(int x, int y) : base(x, y, 96, 192, 9, 0, true, true, true, 1f, 0, 0)
        {
            AnimationSide = 1;
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
        }
    }
}
