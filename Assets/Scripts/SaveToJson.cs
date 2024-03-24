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
        // 指定JSON文件保存路径
        string filePath = Application.persistentDataPath + "/GameData.json";

        // 将PlayerData对象转换为JSON格式的字符串
        string jsonData = JsonMapper.ToJson(data);

        // 将JSON字符串写入到本地文件中
        File.WriteAllText(filePath, jsonData);

        Debug.Log("Player data saved to: " + filePath);
    }
}
