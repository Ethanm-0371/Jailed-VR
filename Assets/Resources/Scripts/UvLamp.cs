using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MagicLightSource : MonoBehaviour
{
    public Material reveal;
    public Light uvLight;

    void Update()
    {
        reveal.SetVector("_LightPosition", uvLight.transform.position);
        reveal.SetVector("_LightDirection", -uvLight.transform.forward);
        reveal.SetFloat("_LightAngle", uvLight.spotAngle);
    }
}