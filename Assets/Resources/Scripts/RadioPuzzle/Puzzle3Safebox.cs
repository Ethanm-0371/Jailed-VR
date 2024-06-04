using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3Safebox : MonoBehaviour
{
    [SerializeField] GameObject[] objectsToRotate;
    [SerializeField] GameObject key;
    AudioSource audioSource;

    float currentTime;
    float angleToRotate;
    bool open;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
                GO.transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(angleToRotate, 0, 0), currentTime);
            }

            currentTime += Time.deltaTime;
        }
    }

    public void OpenSafebox()
    {
        open = true;
        audioSource.PlayOneShot(audioSource.clip);
        key.SetActive(true);
    }
}
