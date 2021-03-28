using Apos.Gui;
using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music_Game
{
    class Test : Game_Scene
    {
        SpriteFont font;
        Vector2 FPS;
        Vector2 Text;
        Game game;
        bool _showFun = false;
        IMGUI _ui;
        public override void Init(GraphicsDeviceManager _graphics, ContentManager Content, GraphicsDevice GraphicsDevice, ScreenManager screenManager, Game game)
        {
            this.game = game;
            FPS = new Vector2(10, 10);
            font = Content.Load<SpriteFont>("File");
            FontSystem fontSystem = FontSystemFactory.Create(GraphicsDevice, 2048, 2048);
            fontSystem.AddFont(TitleContainer.OpenStream($"{Content.RootDirectory}/Monaco-1.ttf"));

            GuiHelper.Setup(game, fontSystem);

            _ui = new IMGUI();
            Text = new Vector2(30, 30);
            base.Init(_graphics, Content, GraphicsDevice, screenManager, game);
        }

        public override void Update(GameTime gameTime)
        {
            GuiHelper.UpdateSetup();
            _ui.UpdateAll(gameTime);

            // Create your UI.
            Panel.Push().XY = new Vector2(100, 100);
            if (Button.Put("Show fun").Clicked)
            {
                _showFun = !_showFun;
            }
            if (_showFun)
            {
                Label.Put("This is fun!");
            }
            if (Button.Put("Quit").Clicked)
            {
                //Exit();
            }
            Panel.Pop();

            // Call UpdateCleanup at the end.
            GuiHelper.UpdateCleanup();

            base.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            _ui.Draw(gameTime);
            spriteBatch.DrawString(font, ((int)Math.Ceiling(1000 / (float)gameTime.ElapsedGameTime.TotalMilliseconds)).ToString(), FPS, Color.White);
            spriteBatch.DrawString(font, ((int)Math.Ceiling(1000 / (float)gameTime.ElapsedGameTime.TotalMilliseconds)).ToString(), Text, Color.White);
        }
    }
}
