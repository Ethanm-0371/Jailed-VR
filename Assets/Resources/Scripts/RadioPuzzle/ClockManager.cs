using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockManager : MonoBehaviour
{
    [SerializeField] GameObject MinuteBar;
    [SerializeField] GameObject HourBar;
    [SerializeField] Puzzle3Safebox safebox;

    private void Update()
    {
        float MinuteTime = Mathf.Round(MinuteBar.transform.localEulerAngles.z / 6);
        float HourTime = Mathf.Round(HourBar.transform.localEulerAngles.z / 360 * 12);

        if (HourTime == 5 && MinuteTime == 30)
        {
            safebox.OpenSafebox();
        }

    }
}
