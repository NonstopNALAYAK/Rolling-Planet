using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenu, gameOvermenu;

    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerController.instance.gameStarted = true;
            mainMenu.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void FacebookLikeButton()
    {
        Application.OpenURL("https://www.facebook.com/NonstopNALAYAK");
    }

    public void AmazingTwinJumpButton()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.nalayak.amazingtwinjump");
    }

    public void DoubleCirclePongButton()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.nalayak.doublecirclepong");
    }

    public void GetSourceOnGitHub()
    {
        Application.OpenURL("https://github.com/NonstopNALAYAK");
    }
}
