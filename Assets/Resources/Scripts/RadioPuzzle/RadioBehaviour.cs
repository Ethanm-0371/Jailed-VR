using TMPro;
using UnityEngine;

public class RadioBehaviour : MonoBehaviour
{
    [SerializeField] int startingFrequency;
    [SerializeField] ChangeAudio changeAudio;
    [SerializeField] ChangeMaterial changeMaterial;
    [SerializeField] TextMeshPro freqText;

    int frequency;

    bool easter1;
    bool easter2;
    bool easter3;

    // Start is called before the first frame update
    void Start()
    {
        frequency = startingFrequency;

        easter1 = false;
        easter2 = false;
        easter3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        ImageAndSound();
        PrintFrequency();
    }

    void ImageAndSound()
    {
        switch (frequency)
        {
            // Hours
            case 150:
                changeMaterial.To(1);
                changeAudio.To(1);
                break;
            // Minute Dec
            case 70:
                changeMaterial.To(2);
                changeAudio.To(2);
                break;
            // Minute Uni
            case 230:
                changeMaterial.To(3);
                changeAudio.To(3);
                break;
            // EasterEgg 1st
            case 100:
                easter1 = true;
                break;
            // Easter Egg 2nd
            case 60:
                if (easter1)
                {

                }
                break;
            // Easter Egg 3rd
            case 240:
                if (easter2)
                {

                }
                break;
            // Easter Egg Key Frequency
            case 140:
                if (easter3)
                {

                }
                break;
            default:
                changeMaterial.To(0);
                changeAudio.To(0);
                break;
        }
    }

    void PrintFrequency()
    {
        freqText.text = frequency.ToString() + " Hz";
    }

    public void CalculateFrequency(float currentAngle)
    {
        if (currentAngle < 120 && currentAngle > -130)
        {
            frequency = -(int)(currentAngle) + 120;
        }
    }
}
