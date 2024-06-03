using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WeightLogic : MonoBehaviour
{
    [SerializeField] GameObject armGO;
    [SerializeField] List<XRSocketInteractor> weightSockets;

    [SerializeField] Transform plateL;
    [SerializeField] Transform plateR;
    [SerializeField] Transform plateLref;
    [SerializeField] Transform plateRref;

    public float weight = 0.0f;
    [SerializeField] float lerpSpeed = 0.2f;
    [SerializeField] float weightSensitivity = 7;

    bool isLerping = false;
    float elapsedTime = 0;

    void OnEnterSocketFunction(SelectEnterEventArgs eventArgs)
    {
        if (eventArgs.interactableObject.transform.tag != "Weights") 
        {
            XRSocketInteractor thang = eventArgs.interactorObject as XRSocketInteractor;
            thang.interactionManager.SelectExit(eventArgs.interactorObject, eventArgs.interactableObject);
        }

        isLerping = true;
        elapsedTime = 0.0f;
        weight += eventArgs.interactableObject.transform.gameObject.GetComponent<Rigidbody>().mass;
        Debug.Log("Total weight is: " + weight.ToString());
    }
    void OnExitSocketFunction(SelectExitEventArgs eventArgs)
    {
        isLerping = true;
        elapsedTime = 0.0f;
        weight -= eventArgs.interactableObject.transform.gameObject.GetComponent<Rigidbody>().mass;
        Debug.Log("Total weight is: " + weight.ToString());
    }

    void Start()
    {
        foreach (XRSocketInteractor socket in weightSockets)
        {
            socket.selectEntered.AddListener(OnEnterSocketFunction);
            socket.selectExited.AddListener(OnExitSocketFunction);
        }

        armGO.transform.localRotation = Quaternion.Euler(Vector3.forward * weight * weightSensitivity);
    }

    void Update()
    {
        if (isLerping)
        {
            Quaternion targetRotation = Quaternion.Euler(Vector3.forward * weight * weightSensitivity);

            elapsedTime += lerpSpeed * Time.deltaTime;
            armGO.transform.localRotation = Quaternion.Lerp(armGO.transform.localRotation, targetRotation, elapsedTime);

            if (armGO.transform.localRotation == targetRotation)
            {
                isLerping = false;
            }

            plateL.position = new Vector3(plateL.position.x, plateLref.position.y, plateL.position.z);
            plateR.position = new Vector3(plateR.position.x, plateRref.position.y, plateR.position.z);
        }
    }
}
