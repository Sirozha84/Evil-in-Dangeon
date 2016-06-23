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

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Box.Gravitation = 1;
            //Настройка экрана
            //Screen.Set(graphics, 1200, 800, 80, 0);
            Screen.Set(graphics, 1560, 800, 80, 0);
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
            Effects.spriteBatch = spriteBatch;
            Box.spriteBatch = spriteBatch; //и классу блока (для рисования)
            
            //Загрузка спрайтов
            Effects.DebugFont = Content.Load<SpriteFont>("Font");
            Effects.PopUpTable = Content.Load<Texture2D>("PopUp");
            Hero.Texture = Content.Load<Texture2D>("Hero");
            Hero.TextureGuns = Content.Load<Texture2D>("Guns");
            Coin.Texture = Content.Load<Texture2D>("Coin");
            Coin.Sound = Content.Load<SoundEffect>("CoinTake");
            Bonus.Texture = Content.Load<Texture2D>("Bonus");
            Flash.Texture = Content.Load<Texture2D>("Flash");
            Bullet.SountRikoshet = Content.Load<SoundEffect>("BulletRikoshet");
            BulletPistol.Texture = Content.Load<Texture2D>("Bullet");
            BulletPistol.Sound = Content.Load<SoundEffect>("BulletShot");
            Bone.Texture = Content.Load <Texture2D>("Bone");
            Bone.Sound = Content.Load<SoundEffect>("BulletShot");
            PoisonDrop.Texture = Content.Load<Texture2D>("PoisonDrop");
            PoisonDrop.Sound = Content.Load<SoundEffect>("BulletShot");
            SpiderOnWeb.Texture = Content.Load<Texture2D>("SpiderOnWeb");
            SpiderOnWeb.Web = Content.Load<Texture2D>("Pixel");
            Monster.LifeBar = Content.Load<Texture2D>("LifeBar");
            Spider.Texture = Content.Load<Texture2D>("Spider");
            SpiderPoison.Texture = Content.Load<Texture2D>("Spider");
            Skeleton.Texture = Content.Load<Texture2D>("Skeleton");
            Blood.Texture = Content.Load<Texture2D>("Blood");
            Table.Texture = Content.Load<Texture2D>("Table");
            Table.Font = Content.Load<SpriteFont>("Font");
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
            //Рисование игрового статуса
            Effects.DrawGameStatus(World.Players[0] as Hero);
        }
    }
}
