using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SGen;

namespace Evil_in_Dangeon
{
    class SpiderOnWeb : Monster
    {
        public static Texture2D Texture;
        public static Texture2D Web;
        int top;
        int napY;
        int timer;

        public SpiderOnWeb(int x, int y) : base(x, y, 80, 80, 0, 0, 1, 1)
        {
            //Отпределим точку начала паутины
            int yy = -Screen.TileSize;
            int weblen = 0;
            while (WhatIsTiler(0, yy) != 1)
            {
                weblen += Screen.TileSize;
                yy -= Screen.TileSize;
            }
            top = (int)Position.Y - weblen;
            //Начальное направление движения
            napY = RND.Next(2) == 0 ? 1 : -1;
        }

        protected override void DrawMonster()
        {
            int weblen = (int)Position.Y - top;
            Draw(Web, new Rectangle(38, -weblen, 4, weblen), new Rectangle(0, 0, 4, 4));
            Draw(Texture, timerRed == 0 ? Color.White : Color.Red);
        }

        protected override void UpdateMonster()
        {
            if (WhatIsTiler(0, 0) == 1) napY = 1;
            if (WhatIsTiler(0, 80) == 1) napY = -1;
            Position.Y += napY;
            timer++;
            if (timer > 10)
            {
                timer = 0;
                AnimationFrame++;
                if (AnimationFrame > 1) AnimationFrame = 0;
            }
        }
    }
}
