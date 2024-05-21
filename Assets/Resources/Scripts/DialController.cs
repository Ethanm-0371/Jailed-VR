using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DialController : MonoBehaviour
{
    /// <summary>
    /// Dial starting angle
    /// </summary>
    [SerializeField] float startAngle;
    [SerializeField] GameObject rightHand;
    [SerializeField] XRBaseController controller;
    [SerializeField] XRDirectInteractor controllerInteractor;

    /// <summary>
    /// Angle difference needed in order to change dial rotation
    /// </summary>
    [SerializeField] float snapAngle;

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
            float angleToRotate = rightHand.transform.eulerAngles.z - firstHandRotation.eulerAngles.z;


            transform.localRotation = initialDialRotation;
            transform.Rotate(Vector3.up * angleToRotate);

        }
    }
}
