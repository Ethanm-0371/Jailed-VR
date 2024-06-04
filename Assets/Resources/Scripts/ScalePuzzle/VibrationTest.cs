using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VibrationTest : MonoBehaviour
{
    XRBaseController controller;
    XRDirectInteractor controllerInteractor;

    enum PulseState
    {
        D1,
        E,
        A,
        D2,
    }

    PulseState pulseState;

    float pulseTimer;
    float timeBetween;
    float pulseStrength;
    float longPulseDuration;
    float shortPulseDuration;

    private void Start()
    {
        GetComponent<XRGrabInteractable>().selectEntered.AddListener(OnSelectEntered);
        GetComponent<XRGrabInteractable>().selectExited.AddListener(OnSelectExited);

        pulseTimer = 0;
        timeBetween = 0.2f;
        pulseStrength = 0.5f;
        longPulseDuration = 0.8f;
        shortPulseDuration = 0.2f;

        pulseState = PulseState.D1;
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

        pulseState = PulseState.D1;
    }

    private void Update()
    {
        if (controllerInteractor.IsSelecting(GetComponent<XRBaseInteractable>()))
        {
            DoPulses();
        }
    }

    void DoPulses()
    {
        switch (pulseState)
        {
            case PulseState.D1:
                LetterD1Code();
                break;
            case PulseState.E:
                LetterECode();
                break;
            case PulseState.A:
                LetterACode();
                break;
            case PulseState.D2:
                LetterD2Code();
                break;
        }
    }

    void LetterD1Code()
    {
        pulseTimer += Time.deltaTime;

        if (pulseTimer < longPulseDuration)
        {
            LongHaptic();
        }

        if (pulseTimer < longPulseDuration + shortPulseDuration + timeBetween && pulseTimer > longPulseDuration + timeBetween)
        {
            ShortHaptic();
        }

        if (pulseTimer < longPulseDuration + shortPulseDuration + shortPulseDuration + timeBetween * 2 && pulseTimer > longPulseDuration + shortPulseDuration + timeBetween * 2)
        {
            ShortHaptic();
        }
        else
        {
            pulseState = PulseState.E;
            pulseTimer = 0;
        }
    }

    void LetterECode()
    {
        pulseTimer += Time.deltaTime;

        if (pulseTimer < shortPulseDuration)
        {
            ShortHaptic();
        }
        else
        {
            pulseState = PulseState.A;
            pulseTimer = 0;
        }
    }

    void LetterACode()
    {
        pulseTimer += Time.deltaTime;

        if (pulseTimer < shortPulseDuration)
        {
            ShortHaptic();
        }

        if (pulseTimer < longPulseDuration + shortPulseDuration + timeBetween && pulseTimer > shortPulseDuration + timeBetween)
        {
            LongHaptic();
        }
        else
        {
            pulseState = PulseState.D2;
            pulseTimer = 0;
        }
    }

    void LetterD2Code()
    {
        pulseTimer += Time.deltaTime;

        if (pulseTimer < longPulseDuration)
        {
            LongHaptic();
        }

        if (pulseTimer < longPulseDuration + shortPulseDuration && pulseTimer > longPulseDuration)
        {
            ShortHaptic();
        }

        if (pulseTimer < longPulseDuration + shortPulseDuration + shortPulseDuration && pulseTimer > longPulseDuration + shortPulseDuration)
        {
            ShortHaptic();
        }
        else
        {
            pulseState = PulseState.D1;
            pulseTimer = 0;
        }
    }

    void ShortHaptic()
    {
        controller.SendHapticImpulse(pulseStrength, shortPulseDuration);
    }

    void LongHaptic()
    {
        controller.SendHapticImpulse(pulseStrength, longPulseDuration);
    }
}
