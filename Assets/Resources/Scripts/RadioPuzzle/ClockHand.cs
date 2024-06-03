using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClockHand : MonoBehaviour
{
    [SerializeField] XRBaseController controller;
    [SerializeField] XRDirectInteractor controllerInteractor;
    Rigidbody body;


    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    { 
        if (!controllerInteractor.IsSelecting(GetComponent<XRBaseInteractable>()))
        {
            body.useGravity = false;
            body.velocity = Vector3.zero;
        }
    }
}
