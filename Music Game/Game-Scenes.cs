using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music_Game
{
    public abstract class Game_Scenes
    {
        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
        }

        public virtual Game_Scenes? Update(GameTime gameTime)
        {
            return null;
        }

        protected void DrawRectangle(SpriteBatch spriteBatch, GraphicsDevice GraphicsDevice, Color color, int Height, int Width, float Top, float Left)
        {
            Color[] data = new Color[100 * 100];
            Texture2D rectTexture = new Texture2D(GraphicsDevice, Width, Height);

            for (int i = 0; i < data.Length; ++i)
                data[i] = color;

            rectTexture.SetData(data);
            var position = new Vector2(Left, Top);
            spriteBatch.Draw(rectTexture, position, color);
        }
    }
}
