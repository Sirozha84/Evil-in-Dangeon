using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SGen;

namespace Evil_in_Dangeon 
{
    abstract class Monster : Box
    {
        public static Texture2D LifeBar;

        int Health;
        int HealthMax;
        public int Damage;
        protected int timerRed = 0;
        int timerlifebar;
        public bool Dead;
        int deadxincrement;
        bool Sleep = true;
        protected Color MonsterColor;
        protected bool Blood;

        public Monster(int x, int y, int width, int height, int side, int top, int health, int damage) :
            base(x, y, width, height, side, top, true, true, true, 1, 0, 1000)
        {
            Health = health;
            HealthMax = health;
            Damage = damage;
        }

        public override void Collision(Box box)
        {
            //Попдаает пуля
            if (box is Bullet)
            {
                Bullet bul = box as Bullet;
                if (!bul.Enemy)
                {
                    GetDamage(bul.Damage, bul.Side);
                    Effects.BulletHit(bul, Blood);
                    bul.Destroy();
                }
            }
            //Попадаем в смертельную зону
            if (box is DeathZone)
            {
                DeathZone zone = box as DeathZone;
                GetDamage(zone.Damage, AnimationSide);
            }
        }

        /// <summary>
        /// Получение повреждений
        /// </summary>
        /// <param name="Damage"></param>
        void GetDamage(int Damage, int side)
        {
            Health -= Damage;
            timerRed = 5;
            timerlifebar = 500;
            //Смерть
            if (Health <= 0)
            {
                UpsideDown = true;
                Dead = true;
                timerRed = 0;
                CollisionTests = false;
                Hard = false;
                Impuls(new Vector2(0, -10));
                deadxincrement = side * 5;
                //Откидываем подарки
                Effects.Loot((int)Position.X + Width / 2, (int)Position.Y + Health / 2, HealthMax);
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
            MonsterColor = timerRed == 0 ? Color.White : Color.Red;
        }

        protected abstract void DrawMonster();
        protected abstract void UpdateMonster();
    }
}
