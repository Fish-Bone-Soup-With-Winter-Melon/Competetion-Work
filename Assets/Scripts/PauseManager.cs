using UnityEngine;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject blurPanel;
    public Button continueButton;
    public Button mainMenuButton;
    public GameObject settingPanel;

    private bool isPaused = false;
    private bool anotherPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;

        if (isPaused)
        {
            pauseMenuUI.SetActive(true);
            blurPanel.SetActive(true);
        }
        else
        {
            pauseMenuUI.SetActive(false);
            blurPanel.SetActive(false);
        }
    }
    void OnlyPause()
    {
        anotherPaused = !anotherPaused;
        Time.timeScale = anotherPaused ? 0 : 1;
    }
    
    public void OnContinueButtonClick()
    {
        Debug.Log("Continue!");
        TogglePause();
    }
    public void OnSettingButtonClick()
    {
        settingPanel.SetActive(true);
        OnlyPause();
    }
    public void OffSettingButtonClick()
    {
        settingPanel.SetActive(false);
        OnlyPause();
    }
    public void OnMainMenuButtonClick()
    {
        Debug.Log("Return to Main Menu");
    }
}
