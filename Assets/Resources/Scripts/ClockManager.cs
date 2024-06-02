using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockManager : MonoBehaviour
{
    [SerializeField] GameObject bigBar;
    [SerializeField] GameObject smallBar;

    private void Update()
    {
        float bigBarTime = Mathf.Round(bigBar.transform.localEulerAngles.z / 6);
        float smallBarTime = Mathf.Round(smallBar.transform.localEulerAngles.z / 360 * 12);
    }
}
