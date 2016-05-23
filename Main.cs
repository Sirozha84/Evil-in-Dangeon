using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using SGen;

namespace Evil_in_Dangeon
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //Элементы SGen
        Screen screen;
        MyWorld world;
        //Шрифт
        SpriteFont Font;
        //Счетчик ФПС
        int second;
        int fps = 0;
        int fpsavg = 0;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Box.Gravitation = 1;
            //Настройка экрана
            //Screen.Set(graphics, 1200, 800, 80, 0);
            Screen.Set(graphics, 1600, 900, 80, 0);
            Screen.SpeedHoming = 0.05f;
            //Screen.Set(graphics, 1920, 1080, 80, 0);
            //graphics.IsFullScreen = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Box.Grounds = new int[] { 1 }; //Назначаем блоки, через которые нельзя проходить
            Box.Platforms = new int[] { 2 }; //Платформы
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Screen.spriteBatch = spriteBatch; //Передаём ссылку на устройство рисования классу экрана
            Box.spriteBatch = spriteBatch; //и классу блока (для рисования)
            
            //Загрузка спрайтов
            Font = Content.Load<SpriteFont>("Font");
            Hero.Texture = Content.Load<Texture2D>("Hero");
            Hero.TextureGuns = Content.Load<Texture2D>("Guns");
            Coin.Texture = Content.Load<Texture2D>("Coin");
            Coin.Sound = Content.Load<SoundEffect>("CoinTake");
            Bonus.Texture = Content.Load<Texture2D>("Bonus");
            Flash.Texture = Content.Load<Texture2D>("Flash");
            Bullet.Texture = Content.Load<Texture2D>("Bullet");
            Bullet.Sound = Content.Load<SoundEffect>("BulletShot");
            Bullet.SountRikoshet = Content.Load<SoundEffect>("BulletRikoshet");
            SpiderOnWeb.Texture = Content.Load<Texture2D>("SpiderOnWeb");
            SpiderOnWeb.Web = Content.Load<Texture2D>("Pixel"); ;
            Monster.LifeBar = Content.Load<Texture2D>("LifeBar");
            Spider.Texture = Content.Load<Texture2D>("Spider"); ;
            //Загрузка уровня
            world = new MyWorld("\\Map.map", this);
            screen = new Screen(World.Players[0]);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Enter)) graphics.ToggleFullScreen();

            //Обновление игрового процесса
            World.Update();
            //Обновление камеры
            screen.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //Рисование сцены
            screen.Draw(GraphicsDevice);

            //Рисование отладочнай информации
            fps++;
            base.Draw(gameTime);
            if (second != DateTime.Now.Second)
            {
                second = DateTime.Now.Second;
                fpsavg = fps;
                fps = 0;
            }
            spriteBatch.Begin();
            spriteBatch.DrawString(Font, "FPS: " + fpsavg, new Vector2(10,10), Color.White);
            spriteBatch.DrawString(Font, "Объектов: " + World.Objects.Count, new Vector2(10, 30), Color.White);
            Hero hero = World.Players[0] as Hero;
            spriteBatch.DrawString(Font, "Позиция: " + hero.Position.X + " x " + hero.Position.Y, new Vector2(10, 50), Color.White);

            spriteBatch.DrawString(Font, "Здоровье: " + hero.Health + " / " + hero.HealthMax, new Vector2(300, 10), Color.White);
            spriteBatch.DrawString(Font, "Деньги: " + hero.Money, new Vector2(300, 30), Color.White);
            spriteBatch.End();
        }
    }
}
