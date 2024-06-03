using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SilverKeyChecker : MonoBehaviour
{
    public XRSocketInteractor silverKeyInteractor;

    public AudioClip unlockSfx;
    private AudioSource audioSource;

    public bool silverUnlocked = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        silverKeyInteractor.selectEntered.AddListener(OnSelectEntered);
    }

    void OnDestroy()
    {
        if (silverKeyInteractor != null)
        {
            silverKeyInteractor.selectEntered.RemoveListener(OnSelectEntered);
        }
    }

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("Object entered socket: " + args.interactableObject.transform.name);
        if (args.interactableObject.transform.name != "PF_SilverKey")
        {
            silverKeyInteractor.interactionManager.SelectExit(silverKeyInteractor, silverKeyInteractor.selectTarget);
        }
        else
        {
            audioSource.PlayOneShot(unlockSfx);
            args.interactableObject.transform.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            args.interactableObject.transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            silverUnlocked = true;
        }
    }
}
