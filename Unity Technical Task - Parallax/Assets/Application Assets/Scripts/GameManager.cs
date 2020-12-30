using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static UnityEvent gameEnded = new UnityEvent();
    public static UnityEvent gameStarted = new UnityEvent();

    [ContextMenu("Start Game")]
    public static void StartGame()
    {
        gameStarted.Invoke();
        AudioManager.instance.ResumeMusic();
        gameStarted.Invoke();
    }
}
