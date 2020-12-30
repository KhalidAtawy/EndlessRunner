using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    bool gamePlaying;

    private void Awake()
    {
        GameManager.gameEnded.AddListener(() => gamePlaying = false);
        GameManager.gameStarted.AddListener(() => gamePlaying = true);
    }

    private void Update()
    {
        if (!gamePlaying)
            return;

        //TODO: parallax code, use as many helper methods and classes as you feel appropriate 
    }
}
