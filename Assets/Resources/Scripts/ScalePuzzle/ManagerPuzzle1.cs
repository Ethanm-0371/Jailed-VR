using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ManagerPuzzle1 : MonoBehaviour
{
    bool heartReleased = false;
    [SerializeField] WeightLogic scale;
    [SerializeField] CryptexLogic cryptex;

    [SerializeField] GameObject heart;
    [SerializeField] GameObject key;

    void Update()
    {
        if (!heartReleased && Mathf.Abs(scale.weight) < 0.01) { ReleaseHeart(); }

        if (cryptex.solved) { ReleaseKey(); }
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
            heart.GetComponent<PoseContainer>().enabled = true;

            rb.AddForce(Vector3.up * releaseStrength);

            scale.enabled = false;
        }
    }

    void ReleaseKey()
    {
        key.GetComponent<Rigidbody>().isKinematic = false;
        key.GetComponent<Rigidbody>().useGravity = true;
    }
}
