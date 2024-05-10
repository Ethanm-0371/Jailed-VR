using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WeightLogic : MonoBehaviour
{
    [SerializeField] GameObject armGO;
    [SerializeField] XRSocketInteractor socket;
    [SerializeField] float lerpTime = 0.2f;
    float weight;

    bool isLerping = false;

    void Start()
    {
        socket.selectEntered.AddListener((eventArgs) => 
        {
            isLerping = true;
            elapsedTime = 0.0f;
            weight = eventArgs.interactableObject.transform.gameObject.GetComponent<Rigidbody>().mass;
        });
        socket.selectExited.AddListener((eventArgs) => { armGO.transform.rotation = Quaternion.identity; });
    }

    float elapsedTime = 0;
    void Update()
    {
        if (isLerping)
        {
            elapsedTime += Time.deltaTime;

            float t = elapsedTime / lerpTime;

            float rotationSensitivity = 10;

            armGO.transform.rotation = Quaternion.Lerp(Quaternion.identity, Quaternion.Euler(-Vector3.forward * weight * rotationSensitivity), elapsedTime);

            if (elapsedTime >= lerpTime)
            {
                isLerping = false;
            }
        }
    }
}
