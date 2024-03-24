using UnityEngine;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject blurPanel;
    public Button continueButton;
    public Button mainMenuButton;
    public GameObject settingPanel;
    public GameObject Panel;

    private bool isPaused = true;
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
        Time.timeScale = isPaused ? 0 : 1;

        if (isPaused && !Panel.activeSelf)
        {
            pauseMenuUI.SetActive(true);
            blurPanel.SetActive(true);
            isPaused = false;
        }
        else if(!isPaused && !Panel.activeSelf)
        {
            pauseMenuUI.SetActive(false);
            blurPanel.SetActive(false);
            isPaused = true;
        }
        else if(isPaused && Panel.activeSelf)
        {
            Panel.SetActive(false);
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
        Application.Quit();
    }
}
