using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Music_Game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ScreenManager screenManager;
        public int windowWidth = 1028, windowHeight = 1028;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        protected override void Initialize()
        {

           // _graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width - 2;
           //_graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height - 2;
            _graphics.IsFullScreen =true;
            //this.Window.Position = new Point(200, 50);
            this.Window.IsBorderless = true;
            //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
            screenManager = new ScreenManager(this, _graphics);
            Screen_Loading_Manager.Screen_Loading(screenManager);
            screenManager.Start();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        protected override void Update(GameTime gameTime)
        {

            screenManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(30, 30, 30));
            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            screenManager.BackgroundScreen(_spriteBatch, gameTime);
            screenManager.Draw(_spriteBatch, gameTime);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
