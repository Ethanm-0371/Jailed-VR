using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    [SerializeField] Material[] materialArray;
    MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    /// <summary>
    /// Spectrogram default -> id 0
    /// Spectrogram 1 -> id 1
    /// Spectrogram 2 -> id 2
    /// Spectrogram 3 -> id 3
    /// </summary>
    /// <param name="id"></param>
    public void To(int id)
    {
        if (meshRenderer.material != materialArray[id]) meshRenderer.material = materialArray[id];
    }
}
