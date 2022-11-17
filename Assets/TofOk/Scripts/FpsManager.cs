using TofAr.V0.Color;
using TofAr.V0.Tof;
using TofAr.V0.Hand;
using UnityEngine;
using UnityEngine.UI;

public class FpsManager : MonoBehaviour
{
    public Text txtColor;
    public Text txtTof;
    public Text txtHand;
    void Update()
    {
        txtColor.text = $"{TofArColorManager.Instance.FrameRate:0.0} fps";
        txtTof.text = $"{TofArTofManager.Instance.FrameRate:0.0} fps";
        txtHand.text = $"{TofArHandManager.Instance.FrameRate:0.0} fps";
    }
}
