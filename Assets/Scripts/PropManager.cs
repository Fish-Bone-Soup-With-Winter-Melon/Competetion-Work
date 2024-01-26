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
    void SpawnProps(/*Optional:pos*/)
    {
        SpriteData spriteData = LoadSpriteData(Asset / Resources);
        PlaceSprites(spriteData);
        // 生成游戏中的道具
    }

    void CollectProp(/*Optional:pos*/)
    {
        // 处理玩家收集道具的逻辑
    }

    public SpriteData LoadSpriteData(string path)
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
        return Resources.Load<Sprite>("path/to/sprites/" + name);
    }

    void PlaceSprites(SpriteData spriteData)
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
                spriteObject.transform.position = spriteInfo.position;
            }
        }
    }


}
//存储道具信息的数据结构
private class PropObj
{
    public Vector3 pos;
    public string type;
}

public class DataVO
{
    public List<PropObj> listObjs = new List<PropObj>();
}


