using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonsController : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.singleton.StartGame();
    }

    public void QuitGame()
    {
        GameManager.singleton.QuitGame();
    }
}
