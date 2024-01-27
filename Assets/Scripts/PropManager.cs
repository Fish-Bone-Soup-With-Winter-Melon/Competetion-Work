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
    void SpawnProps(/*Optional:pos*/)         // ������Ϸ�еĵ���
    {
        SpriteData spriteData = LoadSpriteData(Application.persistentDataPath + "Resources/Props.json");
        PlaceSprites(spriteData);
    }

    void CollectProp(/*Optional:pos*/)
    {
        // ��������ռ����ߵ��߼�
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
        return Resources.Load<Sprite>("props/" + name);//Ĭ�ϵ�����ͼ�ļ��洢��Resouces/props�ļ�����
    }

    void PlaceSprites(SpriteData spriteData)         //������Ҫ��ÿ������λ�ðڷŵ��õĺ���
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
                spriteObject.transform.position = spriteInfo.pos;
            }
        }
    }


}
//�洢������Ϣ�����ݽṹ
public class SpriteInfo
{
    public Vector3 pos;
    public string name;
}

public class SpriteData
{
    public SpriteInfo[] sprites;
}
 //����Ϊ��ȡȫ��Gameobject ���ұ������в㼶Ϊprop�����壬��ȡλ�ú����ƽ��䴢�浽json�ļ��еķ���

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
 //��Ҫ��ʱ����øú�������������Ϣ�����json�ļ���
public void SaveProp()
{
    string json = PropToJson();
    File.WriteAllText(Application.persistentDataPath + "Resources/Props.json", json);
}

