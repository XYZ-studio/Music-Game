using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music_Game
{
    public abstract class Game_Scene
    {

        public virtual void Init(GraphicsDeviceManager _graphics, ContentManager Content, GraphicsDevice GraphicsDevice, ScreenManager screenManager)
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        protected void DrawRectangle(SpriteBatch spriteBatch, GraphicsDevice GraphicsDevice, Color color, int Height, int Width, float Top, float Left, int radius = 0)
        {
            Color[] data = new Color[Width * Height];
            Texture2D rectTexture = new Texture2D(GraphicsDevice, Width, Height);
            if (radius == 0)
                for (int i = 0; i < data.Length; ++i)
                    data[i] = color;
            else
            {
                var side = Math.Sqrt((radius * radius) / 2);
                int x, y;
                for (int i = 0; i < data.Length; ++i)
                {
                    x = i % Width;
                    y = i / Width;
                    if (x < side || Width - side < x)
                    {
                        if (y < side || y > Height - side)
                        {
                            if (Math.Sqrt(Math.Pow(side - x, 2) + Math.Pow(side - y, 2)) < side)
                                data[i] = color;
                            else if (Math.Sqrt(Math.Pow(x - Width + side, 2) + Math.Pow(side - y, 2)) < side)
                                data[i] = color;
                            else if (Math.Sqrt(Math.Pow(side - x, 2) + Math.Pow(y - Height + side, 2)) < side)
                                data[i] = color;
                            else if (Math.Sqrt(Math.Pow(x - Width + side, 2) + Math.Pow(y - Height + side, 2)) < side)
                                data[i] = color;
                        }
                        else
                        {
                            data[i] = color;
                        }
                    }
                    else
                    {
                        data[i] = color;
                    }

                }
            }
            rectTexture.SetData(data);
            var position = new Vector2(Left, Top);
            spriteBatch.Draw(rectTexture, position, color);
        }

        public string SceneName()
        {
            return GetType().Name;
        }
    }

    public class ScreenManager
    {

        private GraphicsDevice GraphicsDevice;
        private GraphicsDeviceManager _graphics;
        private ContentManager _content;
        private Dictionary<String, Game_Scene> ScreensMap;
        private Game_Scene currentScene;

        public ScreenManager(GraphicsDeviceManager _graphics, ContentManager Content, GraphicsDevice GraphicsDevice)
        {
            this.GraphicsDevice = GraphicsDevice;
            this._graphics = _graphics;
            _content = Content;
            ScreensMap = new Dictionary<String, Game_Scene>();
        }

        public void AddScene(Game_Scene Scene)
        {
            Scene.Init(_graphics, _content, GraphicsDevice, this);
            ScreensMap.Add(Scene.SceneName(), Scene);
        }

        public void CutoverScene(String SceneName)
        {
            currentScene = ScreensMap[SceneName];
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            currentScene.Draw(spriteBatch, gameTime);
        }

        public void Update(GameTime gameTime)
        {
            currentScene.Update(gameTime);
        }

        public void BackgroundScreen(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (var item in ScreensMap.Keys)
            {
                if(item == "BackgroundScreen")
                {
                    ScreensMap["BackgroundScreen"].Draw(spriteBatch, gameTime);
                    return;
                }
            }
            
        }

        public void Start()
        {
            foreach (var item in ScreensMap.Keys)
            {
                if (item == "Start")
                {
                    currentScene = ScreensMap["Start"];
                    return;
                }
            }
        }
    }
}
