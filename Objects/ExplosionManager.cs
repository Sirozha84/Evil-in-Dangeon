using System;
using SGen;

namespace Evil_in_Dangeon
{
    class ExplosionManager : Box
    {
        int timer = 0;
        int X, Y, Level, Radius;
        bool Enemy;

        public ExplosionManager(int X, int Y, int Level, bool Enemy) : base(X, Y)
        {
            this.X = X;
            this.Y = Y;
            this.Level = Level;
            this.Enemy = Enemy;
        }

        public override void Update()
        {
            if (timer == 0)
            {
                for (int i = 0; i <= Radius; i++)
                {
                    float alpha = (float)RND.Next(31415) / 5000;
                    World.NewObject(new Explosion(X + (int)(Math.Sin(alpha) * Radius * 10) + RND.Next(Radius) * 5,
                                                  Y + (int)(Math.Cos(alpha) * Radius * 10) + RND.Next(Radius) * 5,
                                                  Enemy));
                }
                Radius++;
                if (Radius > Level) Destroy();
                timer = 2;
            }
            timer--;

            //Звук взрыва, наверное, вставить куда-то сюда, повторяющимся по таймеру
            //и сразу несколько, в зависимости от мощности взрыва
        }

        public override void Collision(Box box) { }
        public override void Draw() { }
        public override void Trigger() { }
    }
}
