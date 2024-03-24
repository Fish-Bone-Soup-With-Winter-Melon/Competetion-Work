using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneControllerI : MonoBehaviour
{
    string[] SceneList = { "op","init","debug","debug1" };
    public int pointer;
    public void LoadScene()
    {
        Debug.Log("pointer:" + pointer);
        SceneManager.LoadScene(SceneList[pointer]);
    }

    public void ReloadScene()
    {
        Debug.Log("pointer:" + pointer);
        SceneManager.LoadScene(SceneList[pointer-1]);
    }

    void QuitGame()
    {
        // 退出游戏
        // 持久化保存
    }
}
