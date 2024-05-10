using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerBehaviour : MonoBehaviour
{
    [SerializeField] GameObject Radio;

    RadioBehaviour radioScript;

    AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        radioScript = Radio.GetComponent<RadioBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (radioScript.frequency)
        {
            // Hours
            case 110.0:

                break;
            // Minute Dec
            case 146.0:

                break;
            // Minute Uni
            case 237.0:

                break;
            // EasterEgg 1st
            case 97.0:

                break;
            // Easter Egg 2nd
            case 65.0:

                break;
            // Easter Egg 3rd
            case 240.0:

                break;
            // Easter Egg Key Frequency
            case 138.0:

                break;
            default:

                break;
        }
    }
}
