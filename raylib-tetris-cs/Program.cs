using Raylib_cs;
using static  UtilsClass.Utils;
using Tetris_Game_Class;
namespace MainApp;
class Program
{
    static double lastUpdateTime = 0;
    public static void Main()
    {

        Color darkBlue = Get_Raylib_Color(44,44,127,255);
        int screenWidth=300;
        int screenHeight=600;
        Raylib.InitWindow(screenWidth,screenHeight, "raylib-Tetris-C-Sharp");
        Raylib.SetTargetFPS(60);
        TetrisGame game = new TetrisGame();
        while (!Raylib.WindowShouldClose())
        {
            game.HandleInput();
            if (EventTriggered(0.2))
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
    public static bool EventTriggered(double interval)
    {
        double currentTime = Raylib.GetTime();
        if (currentTime - lastUpdateTime >= interval)
        {
            lastUpdateTime = currentTime;
            return true;
        }
        return false;
    }
}
