using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandsManager : MonoBehaviour
{
    ControllerManager controllerManager;
    [SerializeField] GameplayHand rightHand;
    [SerializeField] Pose pointPose;
    [SerializeField] XRPokeInteractor pokeInteractor;

    void Start()
    {
        controllerManager = GetComponent<ControllerManager>();
    }

    void Update()
    {
        if (controllerManager.rightController.TryGetFeatureValue(CommonUsages.gripButton, out bool gripPressed))
        {
            if (!rightHand.isGrabbing)
            {
                if (gripPressed)
                {
                    rightHand.transform.parent.GetComponent<SphereCollider>().enabled = false;
                    rightHand.ApplyPose(pointPose);
                    rightHand.DeformCollider();
                    pokeInteractor.enabled = true;
                }
                else
                {
                    rightHand.transform.parent.GetComponent<SphereCollider>().enabled = true;
                    rightHand.ApplyDefaultPose();
                    rightHand.DeformCollider();
                    pokeInteractor.enabled = false;
                }
            }
        }
    }
}
