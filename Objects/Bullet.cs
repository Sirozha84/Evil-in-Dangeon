using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SGen;

namespace Evil_in_Dangeon
{
    class Bullet : Box
    {
        public static Texture2D Texture;
        public static SoundEffect Sound;

        public Bullet(int x, int y, int side) : base(x, y, 8, 4)
        {
            AnimationSide = side;
            Sound.Play();
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
            Position.X += AnimationSide * 20;
        }
    }
}
