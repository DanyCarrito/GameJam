using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum GameState
{
    None,
    MainMenu,
    Instructions,
    Configuration,
    StartGame,
    PlayerDeciding,
    Pause,
    GameOver,
    Victory,
    Restart,
    Resume,
    Quit
}

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject menuPanel, gameOverPanel, victoryPanel, pausePanel, gamePanel, instructionsPanel, configurationPanel;
    public static GameManager instance;
    float timer = 0;

    public GameState gameState;

    private void Awake()
    {
        instance = this;
    }

    public void ChangeGameState(GameState newState)
    {
        gameState = newState;
        switch (gameState)
        {
            case GameState.None:
                break;
            case GameState.MainMenu:
                LoadMainMenu();
                break;
            case GameState.Instructions:
                LoadInstructions();
                break;
            case GameState.Configuration:
                LoadConfiguration();
                break;
            case GameState.StartGame:
                StartGame();
                break;
            case GameState.PlayerDeciding:
                Timer();
                break;
            case GameState.Pause:
                LoadPause();
                break;
            case GameState.GameOver:
                GameOver();
                break;
            case GameState.Victory:
                Victory();
                break;
            case GameState.Restart:
                StartGame();
                break;
            case GameState.Resume:
                ResumeGame();
                break;
            case GameState.Quit:
                QuitGame();
                break;
        }
    }
    public void ChangeGameStateFromEditor(string newState)
    {
        ChangeGameState((GameState)System.Enum.Parse(typeof(GameState), newState));
    }

    void Timer()
    {
        timer += Time.deltaTime;
        if (timer > 90)
        {
            ChangeGameState(GameState.GameOver);
        }
    }

    void LoadMainMenu()
    {
        menuPanel.SetActive(true);
        gamePanel.SetActive(false);
        pausePanel.SetActive(false);
        victoryPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    void LoadInstructions()
    {
        instructionsPanel.SetActive(true);
        configurationPanel.SetActive(false);
        menuPanel.SetActive(false);
        gamePanel.SetActive(false);
        pausePanel.SetActive(false);
        victoryPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    void LoadConfiguration()
    {
        configurationPanel.SetActive(true);
        instructionsPanel.SetActive(false);
        menuPanel.SetActive(false);
        gamePanel.SetActive(false);
        pausePanel.SetActive(false);
        victoryPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    void StartGame()
    {
        SceneManager.LoadScene("SceneDany");
        gamePanel.SetActive(true);
        menuPanel.SetActive(false);
        pausePanel.SetActive(false);
        victoryPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    void LoadPause()
    {
        Time.timeScale = 0f;
        gamePanel.SetActive(false);
        pausePanel.SetActive(true);
        menuPanel.SetActive(false);
        victoryPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        gamePanel.SetActive(true);
        pausePanel.SetActive(false);
        menuPanel.SetActive(false);
        victoryPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }
    void Victory()
    {
        gamePanel.SetActive(false);
        victoryPanel.SetActive(true);
        pausePanel.SetActive(false);
        menuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
        gamePanel.SetActive(false);
        victoryPanel.SetActive(false);
        pausePanel.SetActive(false);
        menuPanel.SetActive(false);
    }

    void QuitGame()
    {
        Application.Quit();
        Debug.Log("Se acabó");
    }
}
