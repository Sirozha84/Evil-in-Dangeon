using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Evil_in_Dangeon
{
    class Bone : Bullet
    {
        public static Texture2D Texture;
        public static SoundEffect Sound;

        public Bone(int x, int y, int Side, int Damage, bool Enemy) :
            base(x, y, 28, 28, Side, true, Damage, Enemy)
        {
            Sound.Play();
            animationFrames = 2;
            Speed = 10;
            Jump(RND.Next(10, 20));
        }

        protected override void DrawBullet()
        {
            Draw(Texture);
        }
    }
}
