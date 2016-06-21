using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SGen;

namespace Evil_in_Dangeon
{
    class Spider : MonsterWalk
    {
        public static Texture2D Texture;

        public Spider(int x, int y) : base(x, y, 80, 80, 0, 28, 1, 1)
        {
            //Параметры хотьбы
            MaxSpeed = 5;
            GoOnlyGround = true;
            //Параметры прыжка
            JumpTime = 10;
            JumpSpeed = 15;
            JumpSprite = false;
            //Параметры стреляния
            ShotTime = 0;
            AnimWalkFrames = 2;
            ShutSprite = false;
            //Есть ли у объекта кровь
            Blood = true;
        }

        protected override void DrawMonster()
        {
            Draw(Texture, MonsterColor);
        }

        protected override void Shot() { }
    }
}
