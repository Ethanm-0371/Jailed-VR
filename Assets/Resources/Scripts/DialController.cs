using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DialController : MonoBehaviour
{
    [SerializeField] float startRotationX;
    [SerializeField] GameObject rightHand;
    [SerializeField] XRBaseController controller;
    [SerializeField] XRDirectInteractor controllerInteractor;

    [SerializeField] float snapAmount;

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
            float newRotationZ = rightHand.transform.rotation.eulerAngles.z;


            Vector3 rotationToSet = transform.rotation.eulerAngles;
            rotationToSet.x = newRotationZ;

            //Debug.Log(rotationToSet);

            transform.localRotation = ();
        }
    }
}
