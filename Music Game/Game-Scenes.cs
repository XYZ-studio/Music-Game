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
    }
}
