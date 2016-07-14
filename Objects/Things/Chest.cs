using Microsoft.Xna.Framework.Graphics;

namespace Evil_in_Dangeon
{
    class Chest : Cache
    {
        public static Texture2D Texture;

        public Chest(int x, int y) : base(x - 20, y - 40, 120, 120, 3)
        {
        }

        public override void Draw()
        {
            Draw(Texture);
        }
    }
}
