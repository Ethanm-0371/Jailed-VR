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

    void Start()
    {
        transform.Rotate(Vector3.up * (startAngle * -1));
    }

    // Update is called once per frame
    void Update()
    {
        // Test
        Quaternion currentRotation = transform.localRotation;

        if (controllerInteractor.IsSelecting(GetComponent<XRBaseInteractable>()))
        {
            transform.localRotation = currentRotation;
            transform.Rotate(Vector3.up * rightHand.transform.eulerAngles.z);
        }
    }
}
