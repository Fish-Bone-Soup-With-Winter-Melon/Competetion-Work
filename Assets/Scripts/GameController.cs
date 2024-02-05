using UnityEngine;
using System.IO;

public class GameController : MonoBehaviour
{
    public MapManager mapManager;
    public UIManager uiManager;
    public PlayerController playerController;
    public SceneManager sceneManager;

    void StartGame()
    {
        // 初始化游戏，设置初始状态。
        // mapManager.GenerateMap();
    }

    void GameOver()
    {
        // 处理游戏结束逻辑
        // uiManager.ShowGameOverScreen();
    }

    void PauseGame()
    {
        // 暂停游戏逻辑
    }

    void ResumeGame()
    {
        // 恢复游戏逻辑
    }

    void Start()
    {
        // 游戏开始时调用
        StartGame();
    }

    void Update()
    {
        // 游戏进行中调用，50ms一次
        playerController.CheckCollision();
        // Debug.Log(playerController.isGround);
        // !!! 为防止出现时序问题，所有其他文件中涉及到随时更新的函数调用必须在本窗口进行。
    }
}
