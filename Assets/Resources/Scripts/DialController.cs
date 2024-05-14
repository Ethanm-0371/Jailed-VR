using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DialController : MonoBehaviour
{
    [SerializeField] float startRotationX;
    [SerializeField] GameObject rightHand;
    [SerializeField] XRBaseController controller;
    [SerializeField] XRDirectInteractor controllerInteractor;

    [SerializeField] float snapAmount;

    // Update is called once per frame
    void Update()
    {
        if (controllerInteractor.IsSelecting(GetComponent<XRBaseInteractable>()))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 90);
            transform.Rotate(Vector3.up * rightHand.transform.eulerAngles.z);
        }
    }
}
