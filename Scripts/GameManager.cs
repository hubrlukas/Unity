using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject ESCGamePanel;
    public TextMeshProUGUI statusText;
    public TextMeshProUGUI pauseText;
    public TextMeshProUGUI countText;

    private bool isPaused = false;
    private bool isGameOver = false;

    private void Start() 
    {
        if ( gameOverPanel != null ) gameOverPanel.SetActive(false);
        if ( ESCGamePanel != null ) ESCGamePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (!isGameOver && Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if ( isPaused ) ResumeGame();
            else PauseGame();
        }
    }

    public void TriggerGameOver( string gameOverText )
    {
        isGameOver = true;
        isPaused = true;
        if ( gameOverPanel != null ) 
        {
            gameOverPanel.SetActive(true);
        }
        if ( statusText != null ) 
        {
            statusText.text = gameOverText;
        }
        Time.timeScale = 0f;
    }

    public void TriggerWin() 
    {
        TriggerGameOver("You win!");
    }

    public void TriggerLose() 
    {
        TriggerGameOver("You lose!");
    }

    public void PauseGame()
    {
        isPaused = true;
        countText.gameObject.SetActive(false);
        if (ESCGamePanel != null) 
        {
            ESCGamePanel.SetActive(true);
        }
        if ( pauseText != null )
        {
            pauseText.text = "Game paused";
        }
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        isPaused = false;
        countText.gameObject.SetActive(true);
        if (ESCGamePanel != null) 
        {
            ESCGamePanel.SetActive(false);
        }
        Time.timeScale = 1f;
    }

    public void RestartGame() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Game ended");
        Application.Quit();
    }
}
