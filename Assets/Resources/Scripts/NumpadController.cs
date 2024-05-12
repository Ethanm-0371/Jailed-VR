using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

public class NumpadController : MonoBehaviour
{
    public List<int> correctPassword = new List<int>();
    private List<int> inputPasswordList = new List<int>();
    [SerializeField] private TMP_Text codeDisplay;
    [SerializeField] private float resetTime = 2f;
    [SerializeField] private string successText;
    [Space(5f)]
    [Header("Keypad Entry Events")]
    public UnityEvent onCorrectPassword;
    public UnityEvent onIncorrectPassword;

    public bool allowMultipleActivations = false;
    private bool hasUsedCorrectCode = false;

    public bool HasUsedCorrectCode { get { return hasUsedCorrectCode; } }

    public void UserNumberEntry(int selectedNum)
    {
        if (inputPasswordList.Count >= 4)
            return;

        inputPasswordList.Add(selectedNum);

        UpdateDisplay();

        if (inputPasswordList.Count >= 4)
            CheckPassword();
    }

    private void CheckPassword()
    {
        for (int i = 0; i < correctPassword.Count; i++)
        {
            if (inputPasswordList[i] != correctPassword[i])
            {
                IncorrectPassword();
                return;
            }
        }

        CorrectPasswordGiven();
    }

    private void CorrectPasswordGiven()
    {
        if (allowMultipleActivations)
        {
            onCorrectPassword.Invoke();
            codeDisplay.text = successText;
            StartCoroutine(ResetNumcode());
        }
        else if (!allowMultipleActivations && !hasUsedCorrectCode)
        {
            onCorrectPassword.Invoke();
            hasUsedCorrectCode = true;
            codeDisplay.text = successText;
        }
    }

    private void IncorrectPassword()
    {
        onIncorrectPassword.Invoke();
        StartCoroutine(ResetNumcode());
    }

    private void UpdateDisplay()
    {
        codeDisplay.text = null;
        for (int i = 0; i < inputPasswordList[i]; i++)
        {
            codeDisplay.text += inputPasswordList[i];
        }
    }

    public void DeleteEntry()
    {
        if (inputPasswordList.Count <= 0)
            return;

        inputPasswordList.RemoveAt(inputPasswordList.Count - 1);

        UpdateDisplay();
    }

    IEnumerator ResetNumcode()
    {
        yield return new WaitForSeconds(resetTime);

        inputPasswordList.Clear();

        codeDisplay.text = "";
    }
}
