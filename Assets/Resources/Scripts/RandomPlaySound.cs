using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlaySound : MonoBehaviour
{
    [Header("Audio settings")]
    AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    [Header("Random play clip")]
    [Range(0.0f, 360.0f)] public float minimumCooldown;
    [Range(0.0f, 360.0f)] public float maximumCooldown;
    bool chosenCooldown = false;
    float playCounter = 0.0f;
    float nextCooldown = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!chosenCooldown)
            ChooseRandomCooldown();

        playCounter += Time.deltaTime;

        if (playCounter >= nextCooldown)
        {
            audioSource.PlayOneShot(audioClip);
            ResetCooldowns();
        }

    }

    void ChooseRandomCooldown()
    {
        nextCooldown = Random.Range(minimumCooldown, maximumCooldown);
        chosenCooldown = true;
    }

    void ResetCooldowns()
    {
        chosenCooldown = false;
        playCounter = 0.0f;
    }
}
