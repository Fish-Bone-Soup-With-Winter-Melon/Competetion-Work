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
        // ��ʼ����Ϸ�����ó�ʼ״̬��
        // mapManager.GenerateMap();
    }

    void GameOver()
    {
        // ������Ϸ�����߼�
        // uiManager.ShowGameOverScreen();
    }

    void PauseGame()
    {
        // ��ͣ��Ϸ�߼�
    }

    void ResumeGame()
    {
        // �ָ���Ϸ�߼�
    }

    void Start()
    {
        // ��Ϸ��ʼʱ����
        StartGame();
    }

    void Update()
    {
        // ��Ϸ�����е��ã�50msһ��
        playerController.CheckCollision();
        // Debug.Log(playerController.isGround);
        // !!! Ϊ��ֹ����ʱ�����⣬���������ļ����漰����ʱ���µĺ������ñ����ڱ����ڽ��С�
    }
}
