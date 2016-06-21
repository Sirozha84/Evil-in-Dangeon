using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SGen;

namespace Evil_in_Dangeon
{
    abstract class Bullet : Box
    {
        public static SoundEffect SountRikoshet;
        public bool Enemy;
        public int Damage;
        public int Speed;
        public float Accuracy;
        public bool Gravity;
        public bool Explosive;
        public int Side;
        int animationTimer;
        protected int animationFrames;

        public Bullet(int x, int y, int Width, int Height, int Side, bool Gravity, int Damage, bool Enemy) :
            base(x - Width / 2, y - Height / 2, Width, Height, 0, 0, false, Gravity, true, 10, 0, 0)
        {
            if (Side > 0) Position.X += 80;
            AnimationSide = Side;
            this.Damage = Damage;
            this.Enemy = Enemy;
            this.Side = Side;
            this.Gravity = Gravity;
        }

        public override void Collision(Box box) { }

        public override void Draw() { DrawBullet(); }

        protected abstract void DrawBullet();

        public override void Trigger() { }

        public override void Update()
        {
            //Обработка движения
            Position.X += AnimationSide * Speed;
            bool end = false;
            if (!Gravity)
            {
                Position.Y += Accuracy;
                end = WhatIsTiler(4, 2) == 1;
            }
            else
                end = Physics(Gravity);
            if (end)
            {
                World.NewObject(new Flash((int)Position.X + Width / 2 - 10, (int)Position.Y + Height / 2 - 10));
                PlayIfVisible(SountRikoshet, false);
                Destroy();
            }
            //Анимация
            animationTimer++;
            if (animationTimer > 3)
            {
                animationTimer = 0;
                AnimationFrame++;
                if (AnimationFrame >= animationFrames)
                    AnimationFrame = 0;
            }
        }
    }
}
