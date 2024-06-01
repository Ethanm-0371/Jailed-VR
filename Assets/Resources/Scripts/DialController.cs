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

    void Start()
    {
        transform.Rotate(Vector3.up * (startAngle * -1));

        GetComponent<XRGrabInteractable>().selectEntered.AddListener(args =>
        {
            firstHandRotation = rightHand.transform.rotation;
            initialDialRotation = transform.rotation;
        });
    }

    // Update is called once per frame
    void Update()
    {
        // Test
        if (controllerInteractor.IsSelecting(GetComponent<XRBaseInteractable>()))
        {
            float lastAngle = transform.rotation.eulerAngles.z;

            float angleToRotate = (rightHand.transform.eulerAngles.z - firstHandRotation.eulerAngles.z) * rotationScale;

            float snappedAngle = Mathf.Round(angleToRotate / snapAngle) * snapAngle;

            transform.localRotation = initialDialRotation;
            transform.Rotate(Vector3.up * snappedAngle);

            float currentAngle = transform.rotation.eulerAngles.z;

            if (currentAngle < lastAngle)
            {
                radio.TakeFrequency();
            }
            else if (currentAngle > lastAngle)
            {
                radio.AddFrequency();
            }

            // ADD VIBRATION
        }
    }
}
