using System;
using System.Collections.Generic;
using System.Text;

namespace Music_Game
{
    class Screen_Loading_Manager
    {
        static public void Screen_Loading(ScreenManager screenManager)
        {
            screenManager.AddScene(new Start());
            screenManager.AddScene(new Test());
        }
    }
}
