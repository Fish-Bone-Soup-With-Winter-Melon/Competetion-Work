using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int player_id;                  //player��Ψһ��ʶ����������player
    public GameObject player_obj;   //player��Ӧ��obj or prefeb����������Ӧ��ֱ�Ӳ���player_obj������
    float speed;                    //���ó�ʼ�ٶȣ�ֱ�Ӹı��ٶȣ���̶��
    float accelerate;               //���ó�ʼ���ٶȣ�ֱ�Ӹı���ٶȣ����棩

    public UIManager uiManager;
    public PropManager propManager;
    public LayerMask GroundLayer;
    public LayerMask IceLayer;
    public LayerMask MudLayer;

    public bool isGround;
    public bool isIce;
    public bool isMud;

    // void Move()
    // {
    //     // ������ҵ��ƶ��߼�
    // }

    // void Jump()
    // {
    //     // ������ҵ���Ծ�߼�
    // }

    // void Dash()
    // {
    //     // ������ҵĳ���߼�
    // }

    public void CheckCollision()
    {
        CheckIsOnHorizontalGround();         //����߼���������ĵ�ǰλ��ΪԲ�ģ�0.1fΪ�뾶������Ƿ���GroundLayer�ཻ
        CheckIsOnHorizontalIce();
        CheckIsOnHorizontalMud();
        // ���������ͼԪ�ص���ײ       //�����ڵ�ͼԪ�ز�������ײ���ߵ����
    }

    void OnTriggerEnter2D(Collider2D other)        //����������ߵ���ײ
    {
        if (other.gameObject.CompareTag("SpeedBoost"))
        {
            propManager.CollectProp(PropManager.PropType.SpeedBoost);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("GravityReverse"))
        {
            propManager.CollectProp(PropManager.PropType.GravityReverse);
            Destroy(other.gameObject);
        }
        // �����������ߵ���ײ
    }       //���������Ӧ��ÿ֡���һ��





    public RaycastHit2D CreateOffsetRaycast(Vector2 offset, Vector2 diraction, float length, LayerMask layer)
    {
        Vector2 playerPosition = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(playerPosition + offset, diraction, length, layer);
        Color rayColor = hit ? Color.red : Color.green;
        Debug.DrawRay(playerPosition + offset, diraction * length, rayColor);
        return hit;
    }

    public void CheckIsOnHorizontalGround(/*int state*/)
    {
        //TODO:STATE

        RaycastHit2D leftCheckRay = CreateOffsetRaycast(new Vector2(-0.5f, 0.0f), Vector2.down, 0.6f, GroundLayer);
        RaycastHit2D rightCheckRay = CreateOffsetRaycast(new Vector2(-0.5f, 0.0f), Vector2.down, 0.6f, GroundLayer);
        if (leftCheckRay || rightCheckRay)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }

    public void CheckIsOnHorizontalIce()
    {
        RaycastHit2D leftCheckRay = CreateOffsetRaycast(new Vector2(-0.5f, 0.0f), Vector2.down, 0.6f, IceLayer);
        RaycastHit2D rightCheckRay = CreateOffsetRaycast(new Vector2(0.5f, 0.0f), Vector2.down, 0.6f, IceLayer);
        if (leftCheckRay || rightCheckRay)
        {
            isIce = true;
        }
        else
        {
            isIce = false;
        }
    }

    public void CheckIsOnHorizontalMud()
    {
        RaycastHit2D leftCheckRay = CreateOffsetRaycast(new Vector2(-0.5f, 0.0f), Vector2.down, 0.6f, MudLayer);
        RaycastHit2D rightCheckRay = CreateOffsetRaycast(new Vector2(-0.5f, 0.0f), Vector2.down, 0.6f, MudLayer);
        if (leftCheckRay || rightCheckRay)
        {
            // ���õ���״̬��Ϊ��
            isMud = true;
        }
        else
        {
            isMud = false;
        }
    }

    void Update()
    {
        CheckCollision();
    }
}
