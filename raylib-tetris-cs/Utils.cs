﻿using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace UtilsClass;
interface IAny;
public class Utils:IAny
{
    public static unsafe sbyte* String_To_SBytePointer(string str)
    {
        // Check if the string is null
        if (str == null) throw new ArgumentNullException(nameof(str));
        
        // Allocate memory for sbyte array
        int length = str.Length;
        sbyte* ptr = (sbyte*) Marshal.AllocHGlobal(length);
        
        // Copy characters to sbyte array
        fixed (char* charPtr = str)
        {
            for (int i = 0; i < length; i++)
            {
                ptr[i] = (sbyte)charPtr[i];
            }
        }
        
        return ptr;
    }
    public static bool EventTriggered(double interval,ref double lastUpdateTime)
    {
        double currentTime = Raylib.GetTime();
        if (currentTime - lastUpdateTime >= interval)
        {
            lastUpdateTime = currentTime;
            return true;
        }
        return false;
    }
    public static List<Color> GetCellColors()
    {
        Color darkGrey = Get_Raylib_Color(26, 31, 40,255);
        Color green = Get_Raylib_Color(47,230,23,255);
        Color red = Get_Raylib_Color(232,18,18,255);
        Color orange = Get_Raylib_Color(226,116,17,255);
        Color yellow = Get_Raylib_Color(237, 234, 4, 255);
        Color purple = Get_Raylib_Color(166, 0, 247, 255);
        Color cyan = Get_Raylib_Color(21, 204, 209, 255);
        Color blue = Get_Raylib_Color(13, 64, 216, 255);
        return new(){ darkGrey, green, red, orange, yellow, purple, cyan, blue };
    }
    public static Color Get_Raylib_Color(int red,int green, int blue,int alpha) 
    {
        return new Color((byte)red, (byte)green, (byte)blue, (byte)alpha);
    }
}