using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SGen;

namespace Evil_in_Dangeon
{
    static class Effects
    {
        public static SpriteBatch spriteBatch;
        public static SpriteFont DebugFont;
        public static Texture2D PopUpTable;
        //Текст Поп-Апа
        static byte popupmode;
        static string[] PopUp;
        static int timerpopup;
        static int str;
        static int chr;
        //Счетчик ФПС
        static int second;
        static int fps = 0;
        static int fpsavg = 0;

        /// <summary>
        /// Попадание пули
        /// </summary>
        /// <param name="bul">Пуля</param>
        /// <param name="Blood">Текёт ли кровь</param>
        public static void BulletHit(Bullet bul, bool Blood)
        {
            if (Blood)
            {
                for (int i = 0; i < 20; i++)
                    World.NewObject(new Blood((int)bul.Position.X + bul.Width / 2,
                        (int)bul.Position.Y + bul.Height / 2));
            }
            else
                World.NewObject(new Flash((int)bul.Position.X + bul.Width / 2 - 10,
                        (int)bul.Position.Y + bul.Height / 2 - 10));
        }

        /// <summary>
        /// Рисование игрового статуса
        /// </summary>
        public static void DrawGameStatus(Hero hero)
        {
            //Счётчик FPS
            fps++;
            //base.Draw(gameTime);
            if (second != DateTime.Now.Second)
            {
                second = DateTime.Now.Second;
                fpsavg = fps;
                fps = 0;
            }

            //Отладочная херня всякая
            spriteBatch.Begin();
            spriteBatch.DrawString(DebugFont, "FPS: " + fpsavg, new Vector2(10, 10), Color.White);
            spriteBatch.DrawString(DebugFont, "Объектов: " + World.Objects.Count, new Vector2(10, 30), Color.White);
            spriteBatch.DrawString(DebugFont, "Позиция: " + hero.Position.X + " x " + hero.Position.Y, new Vector2(10, 50), Color.White);
            spriteBatch.DrawString(DebugFont, "Здоровье: " + hero.Health + " / " + hero.HealthMax, new Vector2(300, 10), Color.White);
            spriteBatch.DrawString(DebugFont, "Деньги: " + hero.Money, new Vector2(300, 30), Color.White);


            //Поп-Ап
            if (popupmode > 0)
            {
                timerpopup++;
                if (popupmode == 1 && timerpopup > 2)
                {
                    timerpopup = 0;
                    chr++;
                    if (chr > PopUp[str].Length - 1)
                    {
                        chr = 0;
                        str++;
                        if (str > PopUp.Length - 1) popupmode = 2;                        
                    }
                }
                if (popupmode == 2 && timerpopup > 30) popupmode = 0;
                spriteBatch.Draw(PopUpTable, new Vector2(Screen.Width / 2 - 384, 64), Color.White);
                for (int i = 0; i <= str; i++)
                {
                    int len = i == str ? chr : PopUp[i].Length;
                    if (i < PopUp.Length)
                        spriteBatch.DrawString(DebugFont, PopUp[i].Substring(0, len),
                            new Vector2(Screen.Width / 2 - 352, 96 + i * 32), Color.White);
                }
            }

            spriteBatch.End();
        }

        public static void HelpPopUp(int MessageNum)
        {
            if (popupmode == 0)
            {
                if (MessageNum == 0)
                {
                    PopUp = new string[] { "Это табличка...",
                        "самая обыкновенная табличка.",
                        "И ничего интеренсого на ней не написано!" };
                }
                timerpopup = 0;
                popupmode = 1;
                str = 0;
                chr = 0;
            }
            if (popupmode == 2)
            {
                timerpopup = 0;
            }
        }
    }
}
