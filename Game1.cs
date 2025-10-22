using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _12_MT1_Assignment
{
    public class Game1 : Game
    {
        Random generator;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D caveTexture, corundumTexture, emeraldTexture, pinkQuartzTexture, quartzTexture;

        Rectangle caveRect, corundumRect, emeraldRect, pinkQuartzRect, quartzRect, window;

        int emeraldPositionX, emeraldPositionY;

        float quartzOpacity;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Window.Title = "Monogame Assignment One";
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;

            caveRect = window;
            corundumRect = new Rectangle(10, 10, 50, 50);
            emeraldRect = new Rectangle(100, 10, 50, 50);
            pinkQuartzRect = new Rectangle(10, 100, 50, 50);
            quartzRect = new Rectangle(200, 10, 50, 50);

            generator = new Random();

            emeraldPositionX = generator.Next(window.Width - emeraldRect.Width);
            emeraldPositionY = generator.Next(window.Height - emeraldRect.Height);
            emeraldRect.X = emeraldPositionX;
            emeraldRect.Y = emeraldPositionY;

            quartzOpacity = generator.Next(30, 100);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            caveTexture = Content.Load<Texture2D>("Images/cave");
            corundumTexture = Content.Load<Texture2D>("Images/Corundum no bg");
            emeraldTexture = Content.Load<Texture2D>("Images/Emerald no bg");
            pinkQuartzTexture = Content.Load<Texture2D>("Images/Pink quartz no bg");
            quartzTexture = Content.Load<Texture2D>("Images/Quartz no bg");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(caveTexture, caveRect, Color.White);
            _spriteBatch.Draw(corundumTexture, corundumRect, Color.White);
            _spriteBatch.Draw(pinkQuartzTexture, pinkQuartzRect, Color.White);
            _spriteBatch.Draw(quartzTexture, quartzRect, Color.White * (quartzOpacity / 100));
            _spriteBatch.Draw(emeraldTexture, emeraldRect, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
