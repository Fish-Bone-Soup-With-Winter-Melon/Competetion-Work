using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enter : MonoBehaviour
{
    public Button targetButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (targetButton.interactable)
            {
                targetButton.onClick.Invoke();
            }
        }
    }
}