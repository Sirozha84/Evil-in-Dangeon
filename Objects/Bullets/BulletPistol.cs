using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Evil_in_Dangeon
{
    class BulletPistol : Bullet
    {
        public static Texture2D Texture;
        public static SoundEffect Sound;

        public BulletPistol(int x, int y, int Side, int Damage, bool Enemy) :
            base(x, y, 8, 4, Side, false, Damage, Enemy)
        {
            Sound.Play();
            Speed = 20;
            Accuracy = RND.Next(-50, 50) / 100f;
        }

        protected override void DrawBullet()
        {
            Draw(Texture);
        }
    }
}
