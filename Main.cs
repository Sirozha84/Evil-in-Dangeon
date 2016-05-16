using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        //Счетчик ФПС
        int second;
        int fps = 0;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //Настройка экрана
            //Screen.Set(graphics, 1200, 800, 80, 0);
            Screen.Set(graphics, 1600, 900, 96, 3);
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
            Hero.Texture = Content.Load<Texture2D>("Hero");

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

            fps++;
            base.Draw(gameTime);
            if (second != DateTime.Now.Second)
            {
                second = DateTime.Now.Second;
                Window.Title = "FPS: " + fps.ToString();
                fps = 0;
            }
        }
    }
}
