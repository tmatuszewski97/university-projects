using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonController : MonoBehaviour
{
    public void BackToMainMenu()
    {
        if (GameManager.singleton.GameStarted)
            GameManager.singleton.GoToMainMenu();
    }
}
