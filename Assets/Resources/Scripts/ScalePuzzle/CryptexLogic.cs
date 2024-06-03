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

    [SerializeField] bool isLerping = false;
    [SerializeField] float elapsedTime = 0;
    [SerializeField] int lerpingDial = 0;
    [SerializeField] float lerpSpeed = 5.0f;

    void Start()
    {
        List<Transform> transformsToAdd = new List<Transform>();

        foreach (Transform child in dialsParent.transform)
        {
            transformsToAdd.Add(child);
        }
        dials = transformsToAdd.ToArray();
    }

    void Update()
    {
        if (isLerping)
        {
            Quaternion targetRotation = Quaternion.Euler(Vector3.right * currentPositions[lerpingDial] * rotationAmount);

            elapsedTime += lerpSpeed * Time.deltaTime;
            dials[lerpingDial].localRotation = Quaternion.Lerp(dials[lerpingDial].localRotation, targetRotation, elapsedTime);

            if (dials[lerpingDial].localRotation.eulerAngles == targetRotation.eulerAngles)
            {
                isLerping = false;
                elapsedTime = 0.0f;
                CheckCode();
            }
        }
    }

    [SerializeField] float rotationAmount = 45.0f;
    public void UpdateDialUp(int dialNum)
    {
        if (solved || isLerping) { return; }

        currentPositions[dialNum]--;
        if (currentPositions[dialNum] < 0) { currentPositions[dialNum] = maxPosition - 1; }

        isLerping = true;
        lerpingDial = dialNum;
    }
    public void UpdateDialDown(int dialNum)
    {
        if (solved || isLerping) { return; }

        currentPositions[dialNum]++;
        if (currentPositions[dialNum] >= maxPosition) { currentPositions[dialNum] = 0; }

        isLerping = true;
        lerpingDial = dialNum;
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
