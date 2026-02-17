using UnityEngine;
using UnityEngine.UI;

public class IntervalManager : MonoBehaviour
{
    public Text txt;
    public TofOkManager tofOkManager;
    public InputField inputField;

    private void Update()
    {
        txt.text = tofOkManager.interval.ToString();
        tofOkManager.interval = int.Parse(inputField.text);
    }
}
