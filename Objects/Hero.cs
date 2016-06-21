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

        public int Gun = 0;
        public int Health = 10;
        public int HealthMax = 10;

        bool pressJump = false;
        bool ground = true;
        int timer = 0;
        bool walk = false;
        bool shot = false;
        int shotAnim = 0;
        int timerdamage = 0;

        public Hero(int x, int y) : base(x, y - 80, 80, 160, 12, 0, true, true, true, 10f, 0, 0)
        {
            AnimationSide = 1;
            MaxSpeed = 10;
            Acceliration = 10;
            JumpSpeed = 20;
        }

        public override void Draw()
        {
            Draw(Texture, timerdamage == 0 ? Color.White : Color.Red);
            if (timerdamage > 0) timerdamage--;
            int x = 0;
            if (AnimationSide < 0) x = -80;
            int f = 0;
            if (shotAnim > 0)
            {
                f = 1;
                shotAnim--;
            }
            else shotAnim = 0;
            Draw(TextureGuns, x, 0, new Rectangle(f * 160, Gun * 160, 160, 160));
        }

        public override void Trigger() { }

        public override void Update()
        {
            //Отскок при получении повреждения
            if (timerdamage > 50)
            {
                if (!Physics(true))
                    if (AnimationSide < 0) GoRight(); else GoLeft();
                return;
            }
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
            //Прыгаем
            if (Keyboard.GetState().IsKeyDown(Keys.Up) & ground & !pressJump)
            {
                Jump();
                pressJump = true;
            }
            pressJump = !(!Keyboard.GetState().IsKeyDown(Keys.Up) & ground);
            ground = Physics(true);
            //Стреляние
            if (Keyboard.GetState().IsKeyDown(Keys.Space) & !shot)
            {
                World.NewObject(new BulletPistol((int)Position.X, (int)Position.Y + 66, AnimationSide, 1, false));
                shot = true;
                shotAnim = 2;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Space)) shot = false;
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
                Coin coin = box as Coin;
                Money += coin.Take();
                World.NewObject(new Bonus((int)Position.X, (int)Position.Y, coin.Nominal));
            }
            //Попадаем в смертельную зону (шипы, газ...)
            if (box is DeathZone)
            {
                DeathZone zone = box as DeathZone;
                GetDamage(zone.Damage);
            }
            //Кусает монстр
            if (box is Monster)
            {
                Monster monster = box as Monster;
                if (!monster.Dead) GetDamage(monster.Damage);
            }
            //Пуля
            if (box is Bullet)
            {
                Bullet bul = box as Bullet;
                if (bul.Enemy)
                {
                    GetDamage(bul.Damage);
                    Effects.BulletHit(bul, true);
                    bul.Destroy();
                }
            }
        }

        //Получение повреждения
        void GetDamage(int damage)
        {
            if (timerdamage == 0)
            {
                timerdamage = 60;
                Impuls(new Vector2(0, -15));
                Physics(true);
                Health -= damage;
                if (Health < 0)
                {
                    Health = 0;
                    //Смерть


                }
            }
        }
    }
}
