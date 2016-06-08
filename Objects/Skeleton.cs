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
        }

        protected override void DrawMonster()
        {
            Draw(Texture);
        }
    }
}
