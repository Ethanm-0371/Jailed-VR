using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudio : MonoBehaviour
{
    [SerializeField] AudioClip[] audioArray;
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Noise -> id 0
    /// Spectrogram 1 -> id 1
    /// Spectrogram 2 -> id 2
    /// Spectrogram 3 -> id 3
    /// </summary>
    /// <param name="id"></param>
    public void To(int id)
    {
        if (source.clip != audioArray[id])
        {
            source.clip = audioArray[id];
            source.Play();
        }
    }

}
