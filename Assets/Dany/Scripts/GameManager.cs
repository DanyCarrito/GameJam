using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum GameState
{
    None,
    MainMenu,
    Instructions,
    StartGame,
    Pause,
    GameOver,
    Victory,
    Restart,
    Resume,
    Quit
}

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject menuPanel, gameOverPanel, victoryPanel, pausePanel, gamePanel, instructionsPanel, listPoints;
    public static GameManager instance;


    [SerializeField] private CameraFollow cameraFollow;
    private Vector3 cameraFollowPosition;
    [SerializeField] private float moveAmount;
    [SerializeField] private float edgeSize;
    [SerializeField] private float rangeWidth;
    [SerializeField] private float rangeHeight;

    public GameState gameState;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //gameState = GameState.MainMenu;
        cameraFollow.Setup(() => cameraFollowPosition);
    }

    private void Update()
    {
        if (cameraFollowPosition.y < rangeWidth)
        {
            if (Input.mousePosition.y > Screen.height - edgeSize)
            {
                cameraFollowPosition.y += moveAmount * Time.deltaTime;
            }
        }

        if (cameraFollowPosition.y > -rangeHeight)
        {
            if (Input.mousePosition.y < edgeSize)
            {
                cameraFollowPosition.y -= moveAmount * Time.deltaTime;
            }
        }
        
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
            case GameState.StartGame:
                StartGame();
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


    void LoadMainMenu()
    {
        hideAllPanels();
        menuPanel.SetActive(true);
    }

    void LoadInstructions()
    {
        hideAllPanels();
        instructionsPanel.SetActive(true);
    }

    void StartGame()
    {
        //SceneManager.LoadScene("Game");
        hideAllPanels();
        gamePanel.SetActive(true);
        listPoints.SetActive(true);
    }

    void LoadPause()
    {
        Time.timeScale = 0f;
        hideAllPanels();
        pausePanel.SetActive(true);
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        hideAllPanels();
        gamePanel.SetActive(true);
    }
    void Victory()
    {
        hideAllPanels();
        victoryPanel.SetActive(true);
    }

    void GameOver()
    {
        hideAllPanels();
        gameOverPanel.SetActive(true);
    }

    void QuitGame()
    {
        Application.Quit();
        Debug.Log("Se acabó");
    }
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void hideAllPanels()
    {
        menuPanel.SetActive(false);
        gamePanel.SetActive(false);
        instructionsPanel.SetActive(false);
        pausePanel.SetActive(false);
        victoryPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        listPoints.SetActive(false);
    }
}
