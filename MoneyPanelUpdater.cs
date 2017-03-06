using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyPanelUpdater : MonoBehaviour 
{
    public Text money;
    public Text multiplier;
    public Text automated;

    void LateUpdate()
    {
        money.text = KeystrokeManager.cash.ToString("c2");
        multiplier.text = "$" + KeystrokeManager.stroke2cash + " / keystroke";
        automated.text = KeystrokeManager.strokesPerSecond + " keystrokes / second";
    }


}
