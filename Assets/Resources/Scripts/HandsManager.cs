using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandsManager : MonoBehaviour
{
    ControllerManager controllerManager;

    [SerializeField] GameplayHand rightHand;
    [SerializeField] GameplayHand leftHand;

    [SerializeField] Pose pointPose;

    void Start()
    {
        controllerManager = GetComponent<ControllerManager>();
    }

    void Update()
    {
        UpdateHand(controllerManager.rightController, rightHand);
        UpdateHand(controllerManager.leftController, leftHand);
    }

    void UpdateHand(InputDevice controller, GameplayHand hand)
    {
        if (controller.TryGetFeatureValue(CommonUsages.gripButton, out bool gripPressed))
        {
            if (!hand.isGrabbing)
            {
                if (gripPressed)
                {
                    hand.transform.parent.GetComponent<SphereCollider>().enabled = false;
                    hand.ApplyPose(pointPose);
                    hand.DeformCollider();
                    hand.transform.GetComponent<XRPokeInteractor>().enabled = true;
                }
                else
                {
                    hand.transform.parent.GetComponent<SphereCollider>().enabled = true;
                    hand.ApplyDefaultPose();
                    hand.DeformCollider();
                    hand.transform.GetComponent<XRPokeInteractor>().enabled = false;
                }
            }
        }
    }
}
