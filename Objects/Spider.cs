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
            MaxSpeed = 5;
            GoOnlyGround = true;
            JumpTime = 10;
            JumpSpeed = 15;
            ShotTime = 0;
            AnimWalkFrames = 2;
            AnimOtherActions = false;
        }

        protected override void DrawMonster()
        {
            Draw(Texture);
        }
    }
}
