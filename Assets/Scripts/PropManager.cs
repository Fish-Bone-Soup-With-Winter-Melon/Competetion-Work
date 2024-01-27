using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PropManager : MonoBehaviour
{
    public PlayerController playerController;
    public enum PropType
    {
        SpeedBoost,GravityReverse,
        // 添加道具类型
    }
    public void CollectProp(PropType propType)
    {
        switch (propType)
        {
            case PropType.SpeedBoost:
                // 处理速度提升道具的逻辑
                Debug.Log("Collected Speed Boost");
                break;

            // 添加其他道具类型的处理逻辑

            default:
                Debug.LogWarning("Unknown prop type");
                break;
        }
    }
    void SpawnProps(/*Optional:pos*/)         // 生成游戏中的道具
    {
        SpriteData spriteData = LoadSpriteData(Application.persistentDataPath + "Resources/Props.json");
        PlaceSprites(spriteData);
    }

    void CollectProp(/*Optional:pos*/)
    {
        // 处理玩家收集道具的逻辑
    }

    public SpriteData LoadSpriteData(string path)              //
    {
        TextAsset textAsset = Resources.Load<TextAsset>(path);
        if (textAsset != null)
        {
            return JsonUtility.FromJson<SpriteData>(textAsset.text);
        }
        else
        {
            Debug.LogError("Unable to load sprite data.");
            return null;
        }
    }

    private Sprite GetSpriteByName(string name)
    {
        return Resources.Load<Sprite>("props/" + name);//默认道具贴图文件存储在Resouces/props文件夹下
    }

    void PlaceSprites(SpriteData spriteData)         //最终需要对每个道具位置摆放调用的函数
    {
        foreach (SpriteInfo spriteInfo in spriteData.sprites)
        {
            Sprite sprite = GetSpriteByName(spriteInfo.name);

            if (sprite != null)
            {
                GameObject spriteObject = new GameObject(spriteInfo.name);
                SpriteRenderer spriteRenderer = spriteObject.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = sprite;

                // 设置位置
                spriteObject.transform.position = spriteInfo.pos;
            }
        }
    }


}
//存储道具信息的数据结构
public class SpriteInfo
{
    public Vector3 pos;
    public string name;
}

public class SpriteData
{
    public SpriteInfo[] sprites;
}
 //以下为读取全部Gameobject 并且遍历其中层级为prop的物体，读取位置和名称将其储存到json文件中的方法

public string PropToJson ()
{
    List<SpriteInfo> spriteInfos = new List<SpriteInfo>();
    foreach (GameObject obj in GameObject.FindObjectsOfType(typeof(GameObject)))
    {
        if (obj.layer == LayerMask.NameToLayer("prop"))
        {
            SpriteInfo info = new SpriteInfo
            {
                pos = obj.transform.position,
                name = obj.name
            };
            sprites.Add(spriteInfos);
        }
    }
    SpriteData spriteData = new SpriteData
    {
        sprites = spriteInfos.ToArray()
    };
    return JsonUtility.ToJson(spriteData , true);
}
 //需要的时候调用该函数，将道具信息保存进json文件中
public void SaveProp()
{
    string json = PropToJson();
    File.WriteAllText(Application.persistentDataPath + "Resources/Props.json", json);
}

