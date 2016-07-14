using Microsoft.Xna.Framework.Graphics;

namespace Evil_in_Dangeon
{
    class Barrel : Cache
    {
        public static Texture2D Texture;

        public Barrel(int x, int y) : base(x, y - 40, 80, 120, 2)
        {
        }

        public override void Draw()
        {
            Draw(Texture);
        }
    }
}
