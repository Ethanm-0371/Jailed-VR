using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public NumpadController numpadController;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            if (numpadController.HasUsedCorrectCode)
            {
                gameObject.SetActive(false);
            }
        }       
    }
}
