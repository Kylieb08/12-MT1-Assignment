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

        MouseState mouseState;

        SpriteFont warningFont;

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
            _graphics.ApplyChanges();

            caveRect = window;
            corundumRect = new Rectangle(360, 383, 50, 50);
            emeraldRect = new Rectangle(100, 10, 50, 50);
            pinkQuartzRect = new Rectangle(662, 399, 50, 50);
            quartzRect = new Rectangle(80, 386, 50, 50);

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

            warningFont = Content.Load<SpriteFont>("Font/Ocular-doom");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            mouseState = Mouse.GetState();
            this.Window.Title = "x = " + mouseState.X + ", y = " + mouseState.Y;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(caveTexture, caveRect, Color.White);

            _spriteBatch.DrawString(warningFont, "WARNING", new Vector2(360, 310), Color.Maroon);

            _spriteBatch.Draw(corundumTexture, corundumRect, null, Color.White * 0.3f,
                4f, new Vector2(corundumTexture.Width / 2, corundumTexture.Height / 2),
                SpriteEffects.FlipVertically, 1f);

            _spriteBatch.Draw(pinkQuartzTexture, pinkQuartzRect, null, Color.White, 
                0f, new Vector2(pinkQuartzTexture.Width / 2, pinkQuartzTexture.Height / 2), 
                SpriteEffects.FlipHorizontally, 1f);

            _spriteBatch.Draw(quartzTexture, quartzRect, Color.White * (quartzOpacity / 100));

            _spriteBatch.Draw(emeraldTexture, emeraldRect, Color.White * 0.85f);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
