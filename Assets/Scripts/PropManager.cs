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
        // ��ӵ�������
    }
    public void CollectProp(PropType propType)
    {
        switch (propType)
        {
            case PropType.SpeedBoost:
                // �����ٶ��������ߵ��߼�
                Debug.Log("Collected Speed Boost");
                break;

            // ��������������͵Ĵ����߼�

            default:
                Debug.LogWarning("Unknown prop type");
                break;
        }
    }
    void SpawnProps(/*Optional:pos*/)
    {
        SpriteData spriteData = LoadSpriteData(Asset / Resources);
        PlaceSprites(spriteData);
        // ������Ϸ�еĵ���
    }

    void CollectProp(/*Optional:pos*/)
    {
        // ��������ռ����ߵ��߼�
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

                // ����λ��
                spriteObject.transform.position = spriteInfo.position;
            }
        }
    }


}
//�洢������Ϣ�����ݽṹ
private class PropObj
{
    public Vector3 pos;
    public string type;
}

public class DataVO
{
    public List<PropObj> listObjs = new List<PropObj>();
}


