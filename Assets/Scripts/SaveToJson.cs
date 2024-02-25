using UnityEngine;
using System.IO;
using LitJson;

public class SaveToJson : MonoBehaviour
{

    public class GameData
    {
        public string playerName;
        public int playerScore;
    }

    void SavePlayerDataToJson(GameData data)
    {
        // ָ��JSON�ļ�����·��
        string filePath = Application.persistentDataPath + "/GameData.json";

        // ��PlayerData����ת��ΪJSON��ʽ���ַ���
        string jsonData = JsonMapper.ToJson(data);

        // ��JSON�ַ���д�뵽�����ļ���
        File.WriteAllText(filePath, jsonData);

        Debug.Log("Player data saved to: " + filePath);
    }
}
