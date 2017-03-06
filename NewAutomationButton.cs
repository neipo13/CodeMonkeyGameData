using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewAutomationButton : MonoBehaviour 
{
    public string type;
    public AutomationManager manager;
    private int number;
    public Text numText;

    void Start()
    {
        number = 0;
    }
    public void ButtonClick()
    {
        if(manager.AddNewTypist(type))
        {
            number++;
            numText.text = number.ToString();
        }
    }
}
