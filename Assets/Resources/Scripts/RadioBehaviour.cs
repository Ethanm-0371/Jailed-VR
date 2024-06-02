using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class RadioBehaviour : MonoBehaviour
{
    [SerializeField] int startingFrequency;
    [SerializeField] int frequency;
    [SerializeField] ChangeAudio changeAudio;
    [SerializeField] DialController dialController;
    [SerializeField] ChangeMaterial changeMaterial;


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

    public void CalculateFrequency(float currentAngle)
    {
        if (currentAngle < 120 && currentAngle > -130)
        {
            frequency = -(int)(currentAngle) + 120;
        }
    }

    //public void AddFrequency()
    //{
    //    if (frequency > 240)
    //    {
    //        frequency = 240;
    //        return;
    //    }

    //    frequency += 10;
    //}
    //public void TakeFrequency()
    //{
    //    if (frequency < 0)
    //    {
    //        frequency = 0;
    //        return;
    //    }

    //    frequency -= 10;
    //}

    //public int GetFrequency()
    //{
    //    return frequency;
    //}
}
