using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SGen;

namespace Evil_in_Dangeon
{
    class Spider : Monster
    {
        public static Texture2D Texture;
        int timeranim;
        int timerside;
        int timerjump;

        public Spider(int x, int y) : base(x, y, 80, 80, 0, 28, 1, 1)
        {
            JumpSpeed = 15;
            MaxSpeed = 5;
            AnimationFrame = RND.Next(2) == 0 ? -1 : 1;
            AnimationSide = RND.Next(2) == 0 ? -1 : 1;
            timerside = RND.Next(30, 60);
            timerjump = RND.Next(30, 60);
        }

        protected override void DrawMonster()
        {
            Draw(Texture);
            timeranim++;
            if (timeranim > 3)
            {
                timeranim = 0;
                AnimationFrame++;
                if (AnimationFrame > 1) AnimationFrame = 0;
            }
        }

        protected override void UpdateMonster()
        {
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
