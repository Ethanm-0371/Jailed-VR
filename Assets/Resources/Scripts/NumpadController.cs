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
    [SerializeField] private float resetTime = 2f;
    [SerializeField] private string successText;
    [Space(5f)]
    [Header("Keypad Entry Events")]
    public UnityEvent onCorrectPassword;
    public UnityEvent onIncorrectPassword;
    [SerializeField] public GameObject objectToTrigger;

    private bool hasUsedCorrectCode = false;

    public bool HasUsedCorrectCode { get { return hasUsedCorrectCode; } }

    public void AddEntry(int selectedNum)
    {
        if (inputPasswordList.Count >= 4)
            return;

        inputPasswordList.Add(selectedNum);

        UpdateDisplay();
    }

    public void DeleteEntry()
    {
        if (inputPasswordList.Count <= 0)
            return;

        inputPasswordList.RemoveAt(inputPasswordList.Count - 1);

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        codeDisplay.text = null;
        for (int i = 0; i < inputPasswordList[i]; i++)
        {
            codeDisplay.text += inputPasswordList[i];
        }
    }

    public void CheckPassword()
    {
        Debug.Log("Checking password.");
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
        onCorrectPassword.Invoke();
        codeDisplay.text = successText;
        TriggerDoor();
    }

    private void IncorrectPassword()
    {
        Debug.Log("Incorrect password given");
        onIncorrectPassword.Invoke();
    }

    public void TriggerDoor()
    {
        objectToTrigger.SetActive(false);
    }
}
