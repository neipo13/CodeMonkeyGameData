using UnityEngine;
using System.Collections;

public class AutomatedTypist 
{
    public float keystrokesPerSecond;
    public float keystrokesMultiplier;
    private float currentStrokes;
    public float initialCost;
    public float increaseAmout;
    public float increaseMulitplier;
    public string type;

    public void Initialize(string t, int count)
    {
        type = t;
        if (type == "monkey")
        {
            keystrokesPerSecond = 1;
            initialCost = 5.00f;
            increaseAmout = 2.00f;
            increaseMulitplier = 1.2f;
        }
        else if (type == "intern")
        {
            keystrokesPerSecond = 5;
            initialCost = 50.00f;
            increaseAmout = 5.00f;
            increaseMulitplier = 1.2f;
        }
        else if (type == "junior")
        {
            keystrokesPerSecond = 25;
            initialCost = 1000.00f;
            increaseAmout = 50.00f;
            increaseMulitplier = 1.2f;
        }
        else if (type == "senior")
        {
            keystrokesPerSecond = 100;
            initialCost = 10000.00f;
            increaseAmout = 300.00f;
            increaseMulitplier = 1.2f;
        }
        currentStrokes = 0;
        keystrokesMultiplier = 1.0f;
    }

	// Update is called once per frame by the AutomationManager
	public void Update () 
    {
        currentStrokes += keystrokesPerSecond * keystrokesMultiplier * Time.deltaTime;
        if(currentStrokes > 1.0f)
        {
            uint strokesToPass = (uint)currentStrokes;
            currentStrokes -= strokesToPass;
            KeystrokeManager.AddStroke(strokesToPass);
        }
	}
}
