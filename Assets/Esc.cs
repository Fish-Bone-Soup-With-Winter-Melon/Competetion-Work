using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Esc : MonoBehaviour
{
    public Button targetButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (targetButton.interactable)
            {
                targetButton.onClick.Invoke();
            }
        }
    }
}