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
    private LayerMask GroundLayer;
    private LayerMask IceLayer;
    private LayerMask MudLayer;

    public bool isGround;
    public bool isIce;
    public bool isMud;

    void Move()
    {
        // ������ҵ��ƶ��߼�
    }

    void Jump()
    {
        // ������ҵ���Ծ�߼�
    }

    void Dash()
    {
        // ������ҵĳ���߼�
    }

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





    // ����Ϊ���������ͼԪ�ص���ײ�ĺ���
    public RaycastHit2D CreateOffsetRaycast(Vector2 offset, Vector2 diraction, float length, LayerMask layer)
    {
        // �����ҵ�ǰ����λ��
        Vector2 playerPosition = transform.position;
        // ������ҵ�ǰλ��ˮƽƫ�Ƶ�����Ͷ����ײ��
        RaycastHit2D hit = Physics2D.Raycast(playerPosition + offset, diraction, length, layer);
        // �����ˮƽ���淢����ײ����ʾ��ɫ����֮����ʾ��ɫ
        Color rayColor = hit ? Color.red : Color.green;
        // ��Scene�ж�̬��ӡͶ����Ĺ���
        Debug.DrawRay(playerPosition + offset, diraction * length, rayColor);
        // �������ɵļ����
        return hit;
    }

    public void CheckIsOnHorizontalGround(/*int state*/)
    {
        //TODO:STATE


        // ����(1)�з���������������������
        RaycastHit2D leftCheckRay = CreateOffsetRaycast(new Vector2(-0.5f, 0.0f), new Vector2(-1f, 0.0f), 0.51f, GroundLayer);
        // ����(1)�з�������������Ҳ�������
        RaycastHit2D rightCheckRay = CreateOffsetRaycast(new Vector2(0.5f, 0.0f), new Vector2(-1f, 0.0f), 0.51f, GroundLayer);
        // �ж�����˫�����Ƿ���ˮƽ����ͼ�㷢����ײ
        if (leftCheckRay || rightCheckRay)
        {
            // ���õ���״̬��Ϊ��
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }

    public void CheckIsOnHorizontalIce()
    {
        // ����(1)�з���������������������
        RaycastHit2D leftCheckRay = CreateOffsetRaycast(new Vector2(-0.5f, 0.0f), new Vector2(-1f, 0.0f), 0.51f, IceLayer);
        // ����(1)�з�������������Ҳ�������
        RaycastHit2D rightCheckRay = CreateOffsetRaycast(new Vector2(0.5f, 0.0f), new Vector2(-1f, 0.0f), 0.51f, IceLayer);
        // �ж�����˫�����Ƿ���ˮƽ����ͼ�㷢����ײ
        if (leftCheckRay || rightCheckRay)
        {
            // ���õ���״̬��Ϊ��
            isIce = true;
        }
        else
        {
            isIce = false;
        }
    }

    public void CheckIsOnHorizontalMud()
    {
        // ����(1)�з���������������������
        RaycastHit2D leftCheckRay = CreateOffsetRaycast(new Vector2(-0.5f, 0.0f), new Vector2(-1f, 0.0f), 0.51f, MudLayer);
        // ����(1)�з�������������Ҳ�������
        RaycastHit2D rightCheckRay = CreateOffsetRaycast(new Vector2(0.5f, 0.0f), new Vector2(-1f, 0.0f), 0.51f, MudLayer);
        // �ж�����˫�����Ƿ���ˮƽ����ͼ�㷢����ײ
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
}
