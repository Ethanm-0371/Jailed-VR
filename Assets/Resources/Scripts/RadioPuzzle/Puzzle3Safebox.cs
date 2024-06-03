using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3Safebox : MonoBehaviour
{
    [SerializeField] GameObject[] objectsToRotate;
    [SerializeField] GameObject key;

    float currentTime;
    float angleToRotate;
    bool open;


    private void Start()
    {
        angleToRotate = -150;
        currentTime = 0;
        open = false;
    }

    private void Update()
    {
        if (open)
        {
            foreach (var GO in objectsToRotate)
            {
                GO.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(angleToRotate, 90, 0), currentTime);
            }

            currentTime += Time.deltaTime;
        }
    }

    public void OpenSafebox()
    {
        open = true;
        key.SetActive(true);
    }
}
