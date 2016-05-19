using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SGen;

namespace Evil_in_Dangeon
{
    class Hero : Box
    {
        public int Money;


        public static Texture2D Texture;
        bool Jump = false;
        bool pressJump = false;
        public Hero(int x, int y) : base(x, y - 80, 80, 160, 12, 0, true, true, true, 10f, 0, 0)
        {
            AnimationSide = 1;
            MaxSpeed = 10;
            Acceliration = 10;
            JumpSpeed = 20;
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
            //Управление
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                GoLeft();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                GoRight();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) & !Jump & !pressJump)
            {
                Jump();
                Jump = true;
                pressJump = true;
            }
            if (!Keyboard.GetState().IsKeyDown(Keys.Up)) pressJump = false;
            if (Physics(true) && Jump) Jump = false;
        }

        public override void Collision(Box box)
        {
            //Берём монетку
            if (box is Coin)
            {
                Coin coin = box as Coin; coin.Take();
                World.NewObject(new Bonus((int)Position.X, (int)Position.Y, coin.Nominal));
            }
        }
    }
}
