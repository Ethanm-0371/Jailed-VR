using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DialController : MonoBehaviour
{
    [SerializeField] GameObject rightHand;
    [SerializeField] RadioBehaviour radio;
    [SerializeField] XRBaseController controller;
    [SerializeField] XRDirectInteractor controllerInteractor;
    
    [SerializeField] float rotationScale;

    float snapAngle;
    float startAngle;
    
    float snappedAngle;

    float vibStrength;
    float vibDuration;

    float lastSnap;
    float lastSnapVibration;

    Quaternion firstHandRotation;
    Quaternion initialDialRotation;


    void Start()
    {
        transform.Rotate(Vector3.up * (startAngle * -1));

        snapAngle = 10;
        startAngle = 0;

        snappedAngle = 0;

        vibStrength = 0.03f;
        vibDuration = 0.01f;

        lastSnap = startAngle;

        GetComponent<XRGrabInteractable>().selectEntered.AddListener(args =>
        {
            firstHandRotation = rightHand.transform.rotation;
            initialDialRotation = transform.rotation;
        });

        GetComponent<XRGrabInteractable>().selectExited.AddListener(args =>
        {
            lastSnap = snappedAngle;
        });
    }

    // Update is called once per frame
    void Update()
    {
        // Test
        if (controllerInteractor.IsSelecting(GetComponent<XRBaseInteractable>()))
        {
            float angleToRotate = Mathf.DeltaAngle(firstHandRotation.eulerAngles.z, rightHand.transform.eulerAngles.z) * rotationScale;

            snappedAngle = Mathf.Round(angleToRotate / snapAngle) * snapAngle;

            if (lastSnapVibration != snappedAngle)
            {
                transform.localRotation = initialDialRotation;
                transform.Rotate(Vector3.forward * -snappedAngle);

                controller.SendHapticImpulse(vibStrength, vibDuration);

                radio.CalculateFrequency(lastSnap + snappedAngle);
                
                lastSnapVibration = snappedAngle;
            }
        }
    }
}