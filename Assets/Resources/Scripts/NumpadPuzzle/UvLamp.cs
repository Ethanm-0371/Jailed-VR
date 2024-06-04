using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MagicLightSource : MonoBehaviour
{
    public Material[] matsToReveal;
    public Light uvLight;

    void Update()
    {
        foreach(Material mat in matsToReveal)
        {
            mat.SetVector("_LightPosition", uvLight.transform.position);
            mat.SetVector("_LightDirection", -uvLight.transform.forward);
            mat.SetFloat("_LightAngle", uvLight.spotAngle);
        }
    }
}