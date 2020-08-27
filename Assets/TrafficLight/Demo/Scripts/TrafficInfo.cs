using UnityEngine;
using UnityEngine.UI;

public class TrafficInfo : MonoBehaviour
{
    public Text text;

    public TrafficLightController TrafficController;
    private void OnEnable()
    {
        TrafficController.OnColorChange += TrafficController_OnColorChange;
    }

    private void OnDisable()
    {
        TrafficController.OnColorChange -= TrafficController_OnColorChange;
    }

    private void TrafficController_OnColorChange(TrafficLightColor color)
    {
        text.text = color.Description;
        text.color = new Color(color.Color.r, color.Color.g, color.Color.b);
    }
}
