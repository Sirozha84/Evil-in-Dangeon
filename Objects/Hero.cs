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
        public static Texture2D TextureGuns;

        public static int Gun = 0;
        bool Jump = false;
        bool pressJump = false;
        bool ground = true;
        int timer = 0;
        bool walk = false;

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
            int x = 0;
            if (AnimationSide < 0) x = -80;
            Draw(TextureGuns, x, 0, new Rectangle(Gun * 80, 0, 160, 160));
        }

        public override void Trigger()
        {
        }

        public override void Update()
        {
            //Управление
            //Ходим
            walk = false;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                AnimationSide = -1;
                GoLeft();
                GoAnimation();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                AnimationSide = 1;
                GoRight();
                GoAnimation();
            }
            //Не ходим
            if (!walk) AnimationFrame = 0;
            if (Keyboard.GetState().IsKeyDown(Keys.Up) & ground & !pressJump)
            {
                Jump();
                pressJump = true;
            }
            pressJump = !(!Keyboard.GetState().IsKeyDown(Keys.Up) & ground);
            ground = Physics(true);
        }

        void GoAnimation()
        {
            if (!ground)
                AnimationFrame = 0;
            else
            {
                timer++;
                if (timer > 2)
                {
                    timer = 0;
                    AnimationFrame++;
                    if (AnimationFrame > 4) AnimationFrame = 1;
                }
                walk = true;
            }
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
