using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneControllerI : MonoBehaviour
{
    string[] SceneList = { "init","DebugScenes/1" };
    int pointer = 1;
    public void LoadScene()
    {
        Debug.Log("pointer:" + pointer);
        // SceneManager.LoadScene(SceneList[pointer]);
    }

    void ReloadScene()
    {
        // ���¼��ص�ǰ����
    }

    void QuitGame()
    {
        // �˳���Ϸ
        // �־û�����
    }
}
