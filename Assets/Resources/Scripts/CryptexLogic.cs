using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptexLogic : MonoBehaviour
{
    [SerializeField] GameObject dialsParent;
    [SerializeField] int[] targetPositions = { 0,0,0,0 };
    [SerializeField] int maxPosition = 8;

    Transform[] dials;
    [SerializeField] int[] currentPositions = { 0,0,0,0 };

    public bool solved = false;

    void Start()
    {
        List<Transform> transformsToAdd = new List<Transform>();

        foreach (Transform child in dialsParent.transform)
        {
            transformsToAdd.Add(child);
        }
        dials = transformsToAdd.ToArray();
    }

    float rotationAmount = 45.0f;
    public void UpdateDialUp(int dialNum)
    {
        if (solved) { return; }

        currentPositions[dialNum]++;
        if (currentPositions[dialNum] >= 8) { currentPositions[dialNum] = 0; }

        dials[dialNum].Rotate(-Vector3.up * rotationAmount);
        CheckCode();
    }
    public void UpdateDialDown(int dialNum)
    {
        if (solved) { return; }

        currentPositions[dialNum]--;
        if (currentPositions[dialNum] < 0) { currentPositions[dialNum] = maxPosition - 1; }

        dials[dialNum].Rotate(Vector3.up * rotationAmount);
        CheckCode();
    }

    void CheckCode()
    {
        for (int i = 0; i < targetPositions.Length; i++)
        {
            if (currentPositions[i] != targetPositions[i]) { return; }
        }

        solved = true;
    }
}
