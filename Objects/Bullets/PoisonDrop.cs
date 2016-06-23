using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Evil_in_Dangeon
{
    class PoisonDrop : Bullet
    {
        public static Texture2D Texture;
        public static SoundEffect Sound;

        public PoisonDrop(int x, int y, int Side, int Damage, bool Enemy) :
            base(x, y, 24, 12, Side, true, Damage, Enemy)
        {
            PlayIfVisible(Sound, false);
            Speed = 10;
            Jump(RND.Next(10, 20));
        }

        protected override void DrawBullet()
        {
            Draw(Texture);
        }
    }
}
