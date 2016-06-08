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
        protected int timeranim;
        protected int timerside;
        protected int timerjump;

        public MonsterWalk(int x, int y, int width, int height, int side, int top, int health, int damage) : 
            base(x, y, width, height, side, top, health, damage)
        {
            JumpSpeed = 15;
            MaxSpeed = 5;
            AnimationFrame = RND.Next(2) == 0 ? -1 : 1;
            AnimationSide = RND.Next(2) == 0 ? -1 : 1;
            timerside = RND.Next(30, 60);
            timerjump = RND.Next(30, 60);
        }

        protected override void UpdateMonster()
        {
            //Обработка анимации
            if (!Dead)
            {
                timeranim++;
                if (timeranim > 3)
                {
                    timeranim = 0;
                    AnimationFrame++;
                    if (AnimationFrame > 4) AnimationFrame = 1;
                }
            }
            //AI
            timerside--;
            if (timerside == 0)
            {
                timerside = 30;
                AnimationSide = (World.Players[0].Position.X < Position.X) ? -1 : 1;
            }
            timerjump--;
            if (timerjump == 0)
            {
                timerjump = RND.Next(30, 60);
                Jump();
            }
            if (AnimationSide < 0) GoLeft(); else GoRight();
            Physics(true);

        }
    }
}
