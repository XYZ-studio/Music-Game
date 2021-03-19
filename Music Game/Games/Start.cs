using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music_Game
{
    class Start :Game_Scenes
    {
        private GraphicsDeviceManager _graphics;
        private ContentManager _content;
        private Texture2D ballTexture;
        private Vector2 ballPosition;
        private Vector2 FPS;
        private float ballSpeed;
        private SpriteFont font;
        public Start(GraphicsDeviceManager _graphics, ContentManager Content)
        {
            this._graphics = _graphics;
            this._content = Content;
            ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
                _graphics.PreferredBackBufferHeight / 2);
            FPS = new Vector2(10, 10);
            ballSpeed = 100f;
            ballTexture = Content.Load<Texture2D>("ball");
            font = Content.Load<SpriteFont>("File");
        }

        public override Game_Scenes Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Seconds > 30)
            {
                return new Test(_graphics, _content);
            }
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
                ballPosition.Y -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Down))
                ballPosition.Y += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Left))
                ballPosition.X -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Right))
                ballPosition.X += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            return null;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(
                ballTexture,
                ballPosition,
                null,
                new Color(255, 255, 255, 0.5f),
                0f,
                new Vector2(ballTexture.Width / 2, ballTexture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );

            spriteBatch.DrawString(font, (gameTime.TotalGameTime.Seconds).ToString(), FPS, Color.White);
        }
    }
}
