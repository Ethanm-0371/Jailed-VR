using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] float transitionTime = 15.0f;
    [SerializeField] float counter = 0.0f;

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0) { return; }

        counter += Time.deltaTime;
        if (counter >= transitionTime)
        {
            ChangeScene("Level_Blockout");
        }
    }

    public void ChangeScene(string targetScene)
    {
        SceneManager.LoadScene(targetScene, LoadSceneMode.Single);
    }
}
