using UnityEngine;
using System.Collections;

public static class KeystrokeManager 
{
    //Bad practice but no time -- GAME JAM YO!
    public static uint totalStrokes;
    public static uint userStrokes;
    private static float remainderStrokes = 0.0f;
    public static float strokeMultiplier = 1.0f;
    public static float strokesPerSecond = 0.0f;


    public static double cash;
    public static double totalCash;
    public static float stroke2cash = 0.05f;

    public static void AddUserStroke()
    {
        userStrokes++;
        AddStroke();
    }

    public static void AddStroke(uint incomingStrokes = 1)
    {
        uint strokes;
        remainderStrokes += strokeMultiplier;
        strokes = incomingStrokes + (uint)remainderStrokes;
        remainderStrokes -= strokes;
        totalStrokes += strokes;
        float earned = strokes * stroke2cash;
        cash += earned;
        
        totalCash += earned;
    }

    public static void IncreaseMultiplierAdd(float amt)
    {
        if(amt > 0.0f)
        {
            strokeMultiplier += amt;
        }
    }

    public static void IncreaseMultiplierFactor(float amt)
    {
        if (amt > 1.0f)
        {
            strokeMultiplier *= amt;
        }
    }

    public static bool Buy(float cost)
    {
        bool allowed = false;
        if(cost <= cash)
        {
            allowed = true;
            cash -= cost;
        }
        return allowed;
    }
}
