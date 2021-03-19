using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Music_Game
{
    public class Game1 : Game
    {
        Texture2D ballTexture;
        Vector2 ballPosition;
        Vector2 FPS;
        float ballSpeed;
        SpriteFont font;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Game_Scenes currentScene;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        protected override void Initialize()
        {
            
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width - 2;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height - 2;
            //this.Window.Position = new Point(200, 50);
            this.Window.IsBorderless = true;
            //_graphics.IsFullScreen = true;

            _graphics.ApplyChanges();
            //ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
            //    _graphics.PreferredBackBufferHeight / 2);
            //FPS = new Vector2(10, 10);
            //ballSpeed = 100f;
            currentScene = new Start(_graphics, Content);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //ballTexture = Content.Load<Texture2D>("ball");
            //font = Content.Load<SpriteFont>("File");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
//            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
//                Exit();
            Game_Scenes? Scene =  currentScene.Update(gameTime);
            if (Scene != null)
            {
                this.currentScene = Scene;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(30, 30, 30));
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            currentScene.Draw(_spriteBatch, gameTime);
            //_spriteBatch.Draw(
            //    ballTexture,
            //    ballPosition,
            //    null,
            //    new Color(255,255,255,0.5f),
            //    0f,
            //    new Vector2(ballTexture.Width / 2, ballTexture.Height / 2),
            //    Vector2.One,
            //    SpriteEffects.None,
            //    0f
            //);
            
            //_spriteBatch.DrawString(font, ((int)Math.Ceiling(1000 / (float)gameTime.ElapsedGameTime.TotalMilliseconds)).ToString(), FPS, Color.White);
            _spriteBatch.End();
            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
