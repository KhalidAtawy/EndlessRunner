using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;
using Text = TMPro.TMP_Text;

public class UIManager : MonoBehaviour
{
    [Header("Start Panel")]
    [SerializeField]
    GameObject playPanel;

    private void Awake()
    {
        playPanel.SetActive(true);
    }

    public void PlayGame()
    {
        playPanel.SetActive(false);

        GameManager.StartGame();
        AudioManager.instance.PlayAudio("click");
    }
}
