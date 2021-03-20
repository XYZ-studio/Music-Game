using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;


namespace Music_Game
{
    class Start :Game_Scenes
    {
        private GraphicsDevice GraphicsDevice;
        private GraphicsDeviceManager _graphics;
        private ContentManager _content;
        private Texture2D ballTexture;
        private Vector2 ballPosition;
        private Vector2 FPS;
        private float alpha;
        private SpriteFont font;

        public Start(GraphicsDeviceManager _graphics, ContentManager Content, GraphicsDevice GraphicsDevice)
        {
            this.GraphicsDevice = GraphicsDevice;
            this._graphics = _graphics;
            this._content = Content;
            ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
                _graphics.PreferredBackBufferHeight / 2);
            FPS = new Vector2(10, 10);
            alpha = 1;
            ballTexture = Content.Load<Texture2D>("ball");
            font = Content.Load<SpriteFont>("File");
        }

        public override Game_Scenes Update(GameTime gameTime)
        {
            if (alpha < 0)
            {
                return new Test(_graphics, _content, GraphicsDevice);
            }
            var kstate = Keyboard.GetState();
            alpha -= (float)0.5 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //if (kstate.IsKeyDown(Keys.Up))
            //    ballPosition.Y -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //if (kstate.IsKeyDown(Keys.Down))
            //    ballPosition.Y += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //if (kstate.IsKeyDown(Keys.Left))
            //    ballPosition.X -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //if (kstate.IsKeyDown(Keys.Right))
            //    ballPosition.X += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            return null;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //spriteBatch.Draw(
            //    ballTexture,
            //    ballPosition,
            //    null,
            //    Color.White*alpha,
            //    0f,
            //    new Vector2(ballTexture.Width / 2, ballTexture.Height / 2),
            //    Vector2.One,
            //    SpriteEffects.None,
            //    0f
            //);

            spriteBatch.DrawString(font, "XYZ Studio ", ballPosition, Color.White * alpha);
            spriteBatch.DrawCircle(50, 50, 30, 20, Color.White, 4);
            
        }
    }
}
