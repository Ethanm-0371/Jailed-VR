using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DialController : MonoBehaviour
{
    [SerializeField] float startRotationX;
    [SerializeField] GameObject rightHand;
    [SerializeField] XRBaseController controller;
    [SerializeField] XRDirectInteractor controllerInteractor;

    Vector3 startRotation;

    void Start()
    {
        //startRotation = transform.rotation.eulerAngles;
        //startRotation.x = startRotationX;

        //transform.Rotate(startRotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (controllerInteractor.IsSelecting(GetComponent<XRBaseInteractable>()))
        {
            float newRotationX = rightHand.transform.rotation.eulerAngles.x;
            Vector3 rotationToSet = transform.rotation.eulerAngles;
            rotationToSet.x = newRotationX;

            Debug.Log(rotationToSet);

            transform.Rotate(rotationToSet);
        }
    }
}
