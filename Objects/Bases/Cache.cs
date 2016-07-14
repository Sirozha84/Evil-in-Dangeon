using Microsoft.Xna.Framework.Graphics;
using SGen;

namespace Evil_in_Dangeon
{
    abstract class Cache : Box
    {
        int Level;

        public Cache(int x, int y, int width, int height, int Level) : base(x, y, width, height, 0, 0, true)
        {
            this.Level = Level;
        }

        public override void Collision(Box box)
        {
            if (box is Bullet && !((Bullet)box).Enemy)
            {
                box.Destroy();
                Destroy();
                int x = (int)Position.X + Width / 2;
                int y = (int)Position.Y + Height / 2;
                Effects.Loot(x, y, Level);
                Effects.Explode(x, y, Level, false);
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
