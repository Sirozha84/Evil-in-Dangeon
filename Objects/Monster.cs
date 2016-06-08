using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SGen;

namespace Evil_in_Dangeon 
{
    abstract class Monster : Box
    {
        public static Texture2D LifeBar;

        int Health;
        int HealthMax;
        public int Damage;
        public int timerRed = 0;
        int timerlifebar;
        public bool Dead;
        int deadxincrement;
        bool Sleep = true;

        public Monster(int x, int y, int width, int height, int side, int top, int health, int damage) :
            base(x, y, width, height, side, top, true, true, true, 1, 0, 1000)
        {
            Health = health;
            HealthMax = health;
            Damage = damage;
        }

        public override void Collision(Box box)
        {
            if (box is Bullet)
            {
                Bullet bul = box as Bullet;
                if (!bul.Enemy)
                {
                    Health -= bul.Damage;
                    timerRed = 5;
                    bul.Destroy();
                    timerlifebar = 500;
                    //Тут, возможно стоит сделать брызги крови и тп... покраснение точно надо!

                    //Смерть
                    if (Health <= 0)
                    {
                        UpsideDown = true;
                        Dead = true;
                        timerRed = 0;
                        CollisionTests = false;
                        Hard = false;
                        Impuls(new Vector2(0, -10));
                        deadxincrement = bul.Side * 5;
                    }
                }
            }
        }

        public override void Draw()
        {
            DrawMonster();
            if (timerlifebar > 0 & !Dead)
            {
                Draw(LifeBar, new Rectangle(Width / 2 - 40, -12, 80, 8), new Rectangle(0, 8, 4, 8));
                Draw(LifeBar, new Rectangle(Width / 2 - 40, -12, 80 * Health / HealthMax, 8), new Rectangle(0, 0, 4, 8));
                timerlifebar--;
            }
        }

        public override void Trigger()
        {
            Sleep = false;
        }

        public override void Update()
        {

            if (!Dead)
            {
                if (timerRed > 0) timerRed--;
                if (!Sleep) UpdateMonster();
            }
            else
            {
                Position.X += deadxincrement;
                Physics(true);
            }
        }

        protected abstract void DrawMonster();
        protected abstract void UpdateMonster();
    }
}
