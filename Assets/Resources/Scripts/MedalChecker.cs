using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MedalChecker : MonoBehaviour
{
    // Start is called before the first frame update
    public XRSocketInteractor medalInteractor;
    [SerializeField] public GameObject objectToTrigger;

    public AudioClip medalSfx;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        medalInteractor.selectEntered.AddListener(OnSelectEntered);
    }

    void OnDestroy()
    {
        if (medalInteractor != null)
        {
            medalInteractor.selectEntered.RemoveListener(OnSelectEntered);
        }
    }

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("Object entered socket: " + args.interactableObject.transform.name);
        if (args.interactableObject.transform.name != "Medal")
        {
            medalInteractor.interactionManager.SelectExit(medalInteractor, medalInteractor.selectTarget);
        }
        else
        {
            Debug.Log("Object entered socket: " + medalInteractor.name);
            audioSource.PlayOneShot(medalSfx);
            args.interactableObject.transform.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            args.interactableObject.transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            objectToTrigger.SetActive(true);
        }
    }

}
