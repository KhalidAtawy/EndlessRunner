using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MyGameManager : MonoBehaviour
{
    [SerializeField]
    private BackgroundElement[] backgroundElements;

    private bool startPressed = false;


    void Awake()
    {


    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (startPressed)
        {
            foreach (BackgroundElement element in backgroundElements)
            {
                element.Move();
            }
        }
    }

    public void StartPressed(GameObject btn)
    {
        startPressed = true;
        btn.SetActive(false);

    }
}
