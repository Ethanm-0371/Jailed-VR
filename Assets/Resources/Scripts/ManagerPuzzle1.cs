using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ManagerPuzzle1 : MonoBehaviour
{
    bool heartReleased = false;
    [SerializeField] WeightLogic scale;

    [SerializeField] GameObject heart;

    void Update()
    {
        if (!heartReleased && scale.weight == 0) { ReleaseHeart(); }
    }

    float counter = 0.0f;
    [SerializeField] float releaseTime = 2.0f;
    [SerializeField] float releaseStrength = 50.0f;
    void ReleaseHeart()
    {
        counter += Time.deltaTime;
        if (counter >= releaseTime)
        {
            heartReleased = true;

            heart.transform.SetParent(null);

            Rigidbody rb = heart.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.isKinematic = false;

            heart.GetComponent<XRGrabInteractable>().enabled = true;
            heart.GetComponent<VibrationTest>().enabled = true;

            rb.AddForce(Vector3.up * releaseStrength);

            scale.enabled = false;
        }
    }
}
