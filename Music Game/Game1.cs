using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Music_Game
{
    public class Game1 : Game
    {
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

            _graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width - 2;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height - 2;
            //this.Window.Position = new Point(200, 50);
            this.Window.IsBorderless = true;
            //_graphics.IsFullScreen = true;

            _graphics.ApplyChanges();

            currentScene = new Start(_graphics, Content, GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        protected override void Update(GameTime gameTime)
        {

            Game_Scenes? Scene =  currentScene.Update(gameTime);
            if (Scene != null)
            {
                currentScene = Scene;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(30, 30, 30));
            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            currentScene.Draw(_spriteBatch, gameTime);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
