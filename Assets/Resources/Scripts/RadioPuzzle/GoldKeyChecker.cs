using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GoldKeyChecker : MonoBehaviour
{
    public XRSocketInteractor goldKeyInteractor;

    public AudioClip unlockSfx;
    private AudioSource audioSource;

    public bool goldUnlocked = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        goldKeyInteractor.selectEntered.AddListener(OnSelectEntered);
    }

    void OnDestroy()
    {
        if (goldKeyInteractor != null)
        {
            goldKeyInteractor.selectEntered.RemoveListener(OnSelectEntered);
        }
    }

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("Object entered socket: " + args.interactableObject.transform.name);
        if (args.interactableObject.transform.name != "Gold Key")
        {
            goldKeyInteractor.interactionManager.SelectExit(goldKeyInteractor, goldKeyInteractor.selectTarget);
        }
        else
        {
            audioSource.PlayOneShot(unlockSfx);
            args.interactableObject.transform.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            args.interactableObject.transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            goldUnlocked = true;
        }
    }
}

