using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;


namespace Music_Game
{
    class Start :Game_Scene
    {
        private GraphicsDevice GraphicsDevice;
        private GraphicsDeviceManager _graphics;
        private ContentManager _content;
        private Texture2D ballTexture;
        private Vector2 ballPosition;
        private Vector2 FPS;
        private float alpha;
        private SpriteFont font;
        private ScreenManager screenManager;
        public override void Init(GraphicsDeviceManager _graphics, ContentManager Content, GraphicsDevice GraphicsDevice, ScreenManager screenManager, Game game)
        {
            this.screenManager = screenManager;
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
        public override void Update(GameTime gameTime)
        {
            if(alpha < 0)
            {
                screenManager.CutoverScene("Test");
            }
            var kstate = Keyboard.GetState();
            alpha -= (float)0.5 * (float)gameTime.ElapsedGameTime.TotalSeconds;

        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            DrawRectangle(spriteBatch, GraphicsDevice, Color.White * alpha, 300, 100, 100, 30, 20);
            spriteBatch.DrawString(font, "XYZ Studio", ballPosition, Color.White * alpha);
            spriteBatch.DrawCircle(50, 50, 30, 20, Color.White, 4);
            
        }
    }
}
