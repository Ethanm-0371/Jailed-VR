using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

public class NumpadController : MonoBehaviour
{
    public List<int> correctPassword = new List<int>();
    public List<int> inputPasswordList = new List<int>();
    [SerializeField] private TMP_Text codeDisplay;
    [SerializeField] private string successText;
    [Space(5f)]
    [Header("Keypad Entry Events")]
    public UnityEvent onCorrectPassword;
    public UnityEvent onIncorrectPassword;
    [SerializeField] public GameObject objectToTrigger;
    [SerializeField] private GameObject key;
    [Header("AudioClips")]
    public AudioClip buttonSfx;
    public AudioClip correctSfx;
    public AudioClip incorrectSfx;
    public AudioClip boxOpenSfx;
    private AudioSource audioSource;

    private bool hasUsedCorrectCode = false;

    public bool HasUsedCorrectCode { get { return hasUsedCorrectCode; } }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void AddEntry(int selectedNum)
    {
        audioSource.PlayOneShot(buttonSfx);
        
        if (inputPasswordList.Count >= 4)
            return;

        inputPasswordList.Add(selectedNum);

        UpdateDisplay();
    }

    public void DeleteEntry()
    {
        audioSource.PlayOneShot(buttonSfx);

        if (inputPasswordList.Count <= 0)
            return;

        inputPasswordList.RemoveAt(inputPasswordList.Count - 1);

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        codeDisplay.text = null;
        for (int i = 0; i < inputPasswordList.Count; i++)
        {
            codeDisplay.text += inputPasswordList[i];
        }
    }

    public void CheckPassword()
    {
        Debug.Log("Checking password.");

        if (inputPasswordList.Count > 4)
            return;

        for (int i = 0; i < correctPassword.Count; i++)
        {
            if (inputPasswordList[i] != correctPassword[i])
            {
                IncorrectPassword();
                return;
            }
        }

        CorrectPassword();
    }

    private void CorrectPassword()
    {
        Debug.Log("Correct password given");
        audioSource.PlayOneShot(correctSfx);
        onCorrectPassword.Invoke();
        codeDisplay.text = successText;
        TriggerDoor();
    }

    private void IncorrectPassword()
    {
        Debug.Log("Incorrect password given");
        audioSource.PlayOneShot(incorrectSfx);
        onIncorrectPassword.Invoke();
    }

    public void TriggerDoor()
    {
        Quaternion rotation = Quaternion.Euler(-130, 0, 0);
        objectToTrigger.transform.rotation = rotation;
        key.SetActive(true);
        audioSource.PlayOneShot(boxOpenSfx);
    }
}