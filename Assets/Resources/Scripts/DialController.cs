using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DialController : MonoBehaviour
{
    [SerializeField] GameObject rightHand;
    [SerializeField] RadioBehaviour radio;
    [SerializeField] XRBaseController controller;
    [SerializeField] XRDirectInteractor controllerInteractor;

    [SerializeField] float snapAngle;
    [SerializeField] float startAngle;
    [SerializeField] float rotationScale;

    Quaternion firstHandRotation;
    Quaternion initialDialRotation;

    float snappedAngle;
    float lastSnap;

    void Start()
    {
        transform.Rotate(Vector3.up * (startAngle * -1));

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

            if (lastSnap != snappedAngle)
            {
                transform.localRotation = initialDialRotation;
                transform.Rotate(Vector3.up * snappedAngle);

                radio.CalculateFrequency(lastSnap + snappedAngle);
            }


            // ADD VIBRATION
        }
    }
}