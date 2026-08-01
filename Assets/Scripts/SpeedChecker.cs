using TMPro;
using UnityEngine;
public class SpeedChecker : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI[] handSpeedTxt;
    [SerializeField] Punching leftFist;
    [SerializeField] Punching rightFist;

    private void Update()
    {
        SpeedToTxt(handSpeedTxt[0], leftFist.GetSpeed());
        SpeedToTxt(handSpeedTxt[1], rightFist.GetSpeed());
    }

    private void SpeedToTxt(TextMeshProUGUI textUI, float fistSpeed)
    {
        textUI.text = fistSpeed.ToString();
    }
}
