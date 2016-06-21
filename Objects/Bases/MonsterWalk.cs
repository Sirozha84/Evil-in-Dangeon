using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SGen;

namespace Evil_in_Dangeon
{
    /// <summary>
    /// Абстрактный класс монстра "ходящего, прыгающего и стреляющего"
    /// </summary>
    abstract class MonsterWalk : Monster
    {
        protected int JumpTime;
        protected bool JumpSprite;
        protected bool GoOnlyGround;
        protected int ShotTime;
        protected Type ShotBullet;
        protected int AnimWalkFrames;
        protected bool ShutSprite;
        int timeranim;
        int timerside;
        int timerjump;
        bool jump = false;

        public MonsterWalk(int x, int y, int width, int height, int side, int top, int health, int damage) : 
            base(x, y, width, height, side, top, health, damage)
        {
            AnimationFrame = RND.Next(2) == 0 ? -1 : 1;
            AnimationSide = RND.Next(2) == 0 ? -1 : 1;
            timerside = RND.Next(30, 60);
        }

        protected override void UpdateMonster()
        {
            //Обработка анимации
            if (!Dead & !jump)
            {
                timeranim--;
                if (timeranim <= 0)
                {
                    timeranim = 4;
                    AnimationSet = 0;
                    AnimationFrame++;
                    if (AnimationFrame == AnimWalkFrames) AnimationFrame = 0;
                }
            }
            //Хотьба
            bool ground = Physics(true);
            //if (timerjump <= 0)
            if (AnimationSide < 0) GoLeft(); else GoRight();
            //Поворот
            timerside--;
            if (timerside == 0)
            {
                timerside = 30;
                AnimationSide = (World.Players[0].Position.X < Position.X) ? -1 : 1;
            }
            //Прыжок
            if (JumpTime > 0)
            {
                if (timerjump < 0) timerjump = RND.Next(JumpTime, JumpTime * 2);
                if (!jump) timerjump--;
                if (ground)
                {
                    if (jump) jump = false;
                }
                if (timerjump == 0 && ground)
                {
                    Jump();
                    jump = true;
                    timerjump = RND.Next(JumpTime, JumpTime * 2);
                    if (JumpSprite)
                    {
                        AnimationSet = 1;
                        AnimationFrame = 0;
                    }
                }
            }
            //Поворот, если упёрлись в стену
        }
    }
}
