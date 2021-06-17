using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public bool GameStarted = false;
    public bool GamePaused = false;
    public bool YouLose = false;
    public int Level = 0;
    public int Score = 0;
    public int NumberOfCollisions = 0;
    public float playedTime = 0;

    [SerializeField] private float slowMotionLevel = 0.1f;

    private void Awake()
    {
        if (singleton == null)
            singleton = this;
        else if (singleton != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    } 

    public void StartGame()
    {
        playedTime = 0;
        Level++;
        SceneManager.LoadScene(Level);
        Pause();
        Invoke("DisablePause", 2);
        GameStarted = true;
        Debug.Log("Game started!");
    }

    public void Update()
    {
        playedTime += Time.deltaTime;
    }

    public void QuitGame()
    {
        Debug.Log("Game closed!");
        Application.Quit(0);
    }

    public void EndGame(bool win)
    {
        GameStarted = false;
        Debug.Log("Game ended with score: " + singleton.Score);

        if (!win)
        {
            YouLose = true;
            Invoke("RestartGame", 2*slowMotionLevel);

            // Efekt zwolnionego tempa
            Time.timeScale = slowMotionLevel;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }

        else
        {
            SceneManager.LoadScene(Level);
        }

    }

    public void RestartGame()
    {
        YouLose = false;
        Level = 0;
        Score = 0;
        playedTime = 0;
        NumberOfCollisions = 0;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        StartGame();
    }

    public void GoToMainMenu()
    {
        GameStarted = false;
        Level = 0;
        Score = 0;
        playedTime = 0;
        NumberOfCollisions = 0;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        SceneManager.LoadScene(Level);
    }

    public void NextLevel()
    {
        Level++;
        if (Level < 4)
        {
            SceneManager.LoadScene(Level);
            Pause();
            Invoke("DisablePause", 2);
        }
        if (Level == 4)
        {
            singleton.EndGame(true);
        }
    }

    private void Pause()
    {
        GamePaused = true;
    }

    private void DisablePause()
    {
        GamePaused = false;
    }

}
