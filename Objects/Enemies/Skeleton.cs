using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SGen;

namespace Evil_in_Dangeon
{
    class Skeleton : MonsterWalk
    {
        public static Texture2D Texture;

        public Skeleton(int x, int y) : base(x, y - 80, 80, 160, 0, 0, 3, 1)
        {
<<<<<<< HEAD:Objects/Enemies/Skeleton.cs
            //Параметры хотьбы
            MaxSpeed = 2;
            GoOnlyGround = true;
            //Параметры прыжка
            JumpTime = 0;
            JumpSpeed = 20;
            JumpSprite = true;
            //Параметры стреляния
            ShotTime = 0;
            AnimWalkFrames = 4;
            ShutSprite = true;
=======
            MaxSpeed = 2; //5
            
            GoOnlyGround = true;
            JumpTime = 0;  //30
            JumpSpeed = 0; //15
            ShotTime = 0;
            AnimWalkFrames = 4;
            AnimOtherActions = true;
>>>>>>> origin/master:Objects/Skeleton.cs
        }

        protected override void DrawMonster()
        {
            Draw(Texture);
        }
    }
}
