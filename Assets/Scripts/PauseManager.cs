using UnityEngine;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject blurPanel;
    public Button continueButton;
    public Button mainMenuButton;

    private bool isPaused = false;

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
            continueButton.interactable = true;
            mainMenuButton.interactable = true;
        }
        else
        {
            pauseMenuUI.SetActive(false);
            blurPanel.SetActive(false);
            continueButton.interactable = false;
            mainMenuButton.interactable = false;
        }
    }

    public void OnContinueButtonClick()
    {
        TogglePause();
    }

    public void OnMainMenuButtonClick()
    {
        Debug.Log("Return to Main Menu");
    }
}
