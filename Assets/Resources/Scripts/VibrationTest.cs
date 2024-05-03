using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VibrationTest : MonoBehaviour
{
    [Range(0,1)]
    public float intensity;
    public float duration;

    [SerializeField] XRBaseController controller;

    void Start()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        //Debug.Log("interactable is: " + interactable.ToString());
        //interactable.activated.AddListener(TriggerHaptic);
    }

    float timer = 0.0f;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 360.0f) { timer -= 360; }
        float value = Mathf.Sin(Mathf.Deg2Rad * timer * 50.0f);

        if (value > 0.5)
        {
            TriggerHaptic(controller);
        }
    }


    void TriggerHaptic(BaseInteractionEventArgs eventArgs)
    {
        Debug.Log("Called first trigger active");

        if (eventArgs.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            TriggerHaptic(controllerInteractor.xrController);
        }
    }

    void TriggerHaptic(XRBaseController controller)
    {
        Debug.Log("Called second trigger active");

        if (intensity > 0)
        {
            controller.SendHapticImpulse(intensity, duration);
        }
    }
}
