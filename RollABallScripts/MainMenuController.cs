using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject settingsPanel;
    public TMP_Dropdown enemyDropdown;

    public void OpenSettings() 
    {
        if ( settingsPanel != null ) settingsPanel.SetActive(true);
    }

    public void CloseSettings() 
    {
        if ( settingsPanel != null ) settingsPanel.SetActive(false);
    }

    public void PlayGame()
    {
        if ( enemyDropdown != null )
        {
            int enemyCount = enemyDropdown.value + 1;
            PlayerPrefs.SetInt("EnemyCount", enemyCount);
            PlayerPrefs.Save();
        }
        SceneManager.LoadScene("Minigame");
    }
    
    public void QuitGame() 
    {
        Application.Quit();
        Debug.Log("Game ended");
    }
}
