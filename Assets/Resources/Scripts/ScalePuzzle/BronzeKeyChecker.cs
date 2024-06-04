using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BronzeKeyChecker : MonoBehaviour
{
    public XRSocketInteractor bronzeKeyInteractor;

    public AudioClip unlockSfx;
    private AudioSource audioSource;

    public bool bronzeUnlocked = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        bronzeKeyInteractor.selectEntered.AddListener(OnSelectEntered);
    }

    void OnDestroy()
    {
        if (bronzeKeyInteractor != null)
        {
            bronzeKeyInteractor.selectEntered.RemoveListener(OnSelectEntered);
        }
    }

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("Object entered socket: " + args.interactableObject.transform.name);
        if (args.interactableObject.transform.name != "Bronze Key")
        {
            bronzeKeyInteractor.interactionManager.SelectExit(bronzeKeyInteractor, bronzeKeyInteractor.selectTarget);
        }
        else
        {
            audioSource.PlayOneShot(unlockSfx);
            args.interactableObject.transform.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            args.interactableObject.transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            bronzeUnlocked = true;
        }
    }
}

