using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VibrationTest : MonoBehaviour
{
    [Range(0,1)]
    public float intensity;
    public float duration;

    [SerializeField] XRBaseController controller;
    [SerializeField] XRDirectInteractor controllerInteractor;

    private void Start()
    {
        GetComponent<XRGrabInteractable>().selectEntered.AddListener(OnSelectEntered);
        GetComponent<XRGrabInteractable>().selectExited.AddListener(OnSelectExited);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        controller = args.interactorObject.transform.gameObject.GetComponent<XRBaseController>();
        controllerInteractor = args.interactorObject.transform.gameObject.GetComponent<XRDirectInteractor>();
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        controller = null;
        controllerInteractor = null;
    }

    float timer = 0.0f;
    private void Update()
    {
        if (controllerInteractor.IsSelecting(GetComponent<XRBaseInteractable>()))
        {
            DoPulses();
        }
    }

    void DoPulses()
    {
        timer += Time.deltaTime;

        if (timer > 0.5f) { TriggerHaptic(controller); }

        if (timer > 1.0f) { timer -= 1.0f; }
    }

    //void TriggerHaptic(BaseInteractionEventArgs eventArgs)
    //{
    //    if (eventArgs.interactorObject is XRBaseControllerInteractor controllerInteractor)
    //    {
    //        TriggerHaptic(controllerInteractor.xrController);
    //    }
    //}

    void TriggerHaptic(XRBaseController controller)
    {
        if (intensity > 0)
        {
            controller.SendHapticImpulse(intensity, duration);
        }
    }
}
