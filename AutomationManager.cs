using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AutomationManager : MonoBehaviour
{
    public List<AutomatedTypist> monkeys;
    public Text monkeyCost;
    public List<AutomatedTypist> interns;
    public Text internCost;
    public List<AutomatedTypist> juniors;
    public Text juniorCost;
    public List<AutomatedTypist> seniors;
    public Text seniorCost;

	// Use this for initialization
	void Start ()
    {
        monkeys = new List<AutomatedTypist>();
        interns = new List<AutomatedTypist>();
        juniors = new List<AutomatedTypist>();
        seniors = new List<AutomatedTypist>();
	}

    void Update()
    {
        foreach(AutomatedTypist m in monkeys)
        {
            m.Update();
        }
        foreach (AutomatedTypist i in interns)
        {
            i.Update();
        } 
        foreach (AutomatedTypist j in juniors)
        {
            j.Update();
        }
        foreach (AutomatedTypist s in seniors)
        {
            s.Update();
        }
    }

    public bool AddNewTypist(string type)
    {
        AutomatedTypist t = new AutomatedTypist();
        bool itHappened = false;

        if (type == "monkey")
        {
            t.Initialize(type, monkeys.Count);
            float cost = t.initialCost + t.increaseAmout * monkeys.Count * t.increaseMulitplier;
            if(KeystrokeManager.Buy(cost))
            {
                monkeys.Add(t);
                //update cost after adding unit
                cost = t.initialCost + t.increaseAmout * monkeys.Count * t.increaseMulitplier;
                monkeyCost.text = cost.ToString("c2");
                itHappened = true;
            }
        }
        else if (type == "intern")
        {
            t.Initialize(type, interns.Count);
            float cost = t.initialCost + t.increaseAmout * monkeys.Count * t.increaseMulitplier;
            if(KeystrokeManager.Buy(t.initialCost + t.increaseAmout * interns.Count *t.increaseMulitplier))
            {
                interns.Add(t);
                //update cost after adding unit
                cost = t.initialCost + t.increaseAmout * interns.Count * t.increaseMulitplier;
                internCost.text = cost.ToString("c2");
                itHappened = true;
            }
        }
        else if (type == "junior")
        {
            t.Initialize(type, juniors.Count);
            float cost = t.initialCost + t.increaseAmout * monkeys.Count * t.increaseMulitplier;
            if(KeystrokeManager.Buy(t.initialCost + t.increaseAmout * juniors.Count *t.increaseMulitplier))
            {
                juniors.Add(t);
                //update cost after adding unit
                cost = t.initialCost + t.increaseAmout * juniors.Count * t.increaseMulitplier;
                juniorCost.text = cost.ToString("c2");
                itHappened = true;
            }
        }
        else if (type == "senior")
        {
            t.Initialize(type, seniors.Count);
            float cost = t.initialCost + t.increaseAmout * monkeys.Count * t.increaseMulitplier;
            if (KeystrokeManager.Buy(t.initialCost + t.increaseAmout * seniors.Count * t.increaseMulitplier))
            {
                seniors.Add(t);
                //update cost after adding unit
                cost = t.initialCost + t.increaseAmout * seniors.Count * t.increaseMulitplier;
                seniorCost.text = cost.ToString("c2");
                itHappened = true;
            }
        }
        //Debug.Log(t.type);

        //update keystrokes/second number
        float keystrokesPerSec = 0.0f;
        foreach (AutomatedTypist m in monkeys)
        {
            keystrokesPerSec += m.keystrokesPerSecond;
        }
        foreach (AutomatedTypist i in interns)
        {

            keystrokesPerSec += i.keystrokesPerSecond;
        }
        foreach (AutomatedTypist j in juniors)
        {

            keystrokesPerSec += j.keystrokesPerSecond;
        }
        foreach (AutomatedTypist s in seniors)
        {
            keystrokesPerSec += s.keystrokesPerSecond;
        }
        KeystrokeManager.strokesPerSecond = keystrokesPerSec;

        return itHappened;

    }
}
