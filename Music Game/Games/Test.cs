using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music_Game
{
    class Test : Game_Scenes
    {
        SpriteFont font;
        Vector2 FPS;
        Vector2 Text;
        public Test(GraphicsDeviceManager _graphics, ContentManager Content, GraphicsDevice GraphicsDevice)
        {

            FPS = new Vector2(10, 10);
            font = Content.Load<SpriteFont>("File");
            Text = new Vector2(30, 30);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.DrawString(font, ((int)Math.Ceiling(1000 / (float)gameTime.ElapsedGameTime.TotalMilliseconds)).ToString(), FPS, Color.White);
            spriteBatch.DrawString(font, ((int)Math.Ceiling(1000 / (float)gameTime.ElapsedGameTime.TotalMilliseconds)).ToString(), Text, Color.White);
        }
    }
}
