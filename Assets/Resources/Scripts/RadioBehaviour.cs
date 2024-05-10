using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioBehaviour : MonoBehaviour
{
    [SerializeField] public double frequency;
    [SerializeField] GameObject dialController;

    // Start is called before the first frame update
    void Start()
    {
        frequency = 0.0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
