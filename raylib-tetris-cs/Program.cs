using Raylib_cs;
using static  UtilsClass.Utils;
using Tetris_Game_Class;
using UtilsClass;
namespace MainApp;
unsafe class Program
{
    static double lastUpdateTime = 0;
    public static void Main()
    {
        Font font = Raylib.LoadFontEx("Bigdey_Demo.ttf",64,new int[]{},0);
        Console.WriteLine($"{font.BaseSize}{font.GetHashCode}{font.GlyphCount}{font.GlyphPadding}");
        Color darkBlue = Get_Raylib_Color(44,44,127,255);
        int screenWidth=500;
        int screenHeight=620;
        Raylib.InitWindow(screenWidth,screenHeight, "raylib-Tetris-C-Sharp");
        Raylib.SetTargetFPS(60);
        TetrisGame game = new TetrisGame();
        while (!Raylib.WindowShouldClose())
        {
            game.HandleInput();
            if (Utils.EventTriggered(0.2,ref lastUpdateTime))
            {
                game.MoveBlockDown();
            }
            Raylib.BeginDrawing();
            Raylib.ClearBackground(darkBlue);
            game.Draw();
            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
    }
}
