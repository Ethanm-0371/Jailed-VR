using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    //BronzeKeyChecker bronzeKey;
    [SerializeField] SilverKeyChecker silverKey;
    [SerializeField] GoldKeyChecker goldKey;
    [SerializeField] BronzeKeyChecker bronzeKey;

    [System.NonSerialized]
    bool gameEnded = false;

    // Update is called once per frame
    void Update()
    {
        if (goldKey.goldUnlocked && silverKey.silverUnlocked && bronzeKey.bronzeUnlocked)
        {
            if (!gameEnded)
                EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        // do fadetoBLACK
    }
}
