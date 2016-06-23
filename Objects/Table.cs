using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SGen;

namespace Evil_in_Dangeon
{
    class Table : Box
    {
        public static Texture2D Texture;
        public static SpriteFont Font;

        int MessageNum;

        public Table(int x, int y, int MessageNum) : base(x, y, 80, 80, 0, 0, false, false, false, 0, 0, 100)
        {
            this.MessageNum = MessageNum;
        }

        public override void Collision(Box box) { }

        public override void Draw()
        {
            Draw(Texture);
        }

        public override void Trigger()
        {
            Effects.HelpPopUp(MessageNum);
        }

        public override void Update() { }
    }
}
