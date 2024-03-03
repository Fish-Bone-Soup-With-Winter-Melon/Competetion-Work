using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int player_id;
    public GameObject player_obj;
    float speed;
    float accelerate;

    public UIManager uiManager;
    public PropManager propManager;
    public LayerMask GroundLayer;
    public LayerMask IceLayer;
    public LayerMask MudLayer;

    public bool isGround;
    public bool isIce;
    public bool isMud;
    public float rayLength = 1.7f;

    // void Move()
    // {
    //     
    // }

    // void Jump()
    // {
    //     
    // }

    // void Dash()
    // {
    //    
    // }

    public void CheckCollision()
    {
        CheckIsOnHorizontalGround();
        CheckIsOnHorizontalIce();
        CheckIsOnHorizontalMud();
        // Debug.Log("isIce: " + isIce + " isGround: " + isGround + " isMud: " + isMud);
    }

    void OnTriggerEnter2D(Collider2D other)
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
    }





    public RaycastHit2D CreateOffsetRaycast(Vector2 offset, Vector2 diraction, float length, LayerMask layer)
    {
        Vector2 playerPosition = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(playerPosition + offset, diraction, length, layer);
        Color rayColor = hit ? Color.red : Color.green;
        if (layer == IceLayer)
            Debug.DrawRay(playerPosition + offset, diraction * length, rayColor);
        return hit;
    }

    public void CheckIsOnHorizontalGround(/*int state*/)
    {
        //TODO:STATE

        RaycastHit2D leftCheckRay = CreateOffsetRaycast(new Vector2(-0.45f, 0.0f), Vector2.down, rayLength, GroundLayer);
        RaycastHit2D rightCheckRay = CreateOffsetRaycast(new Vector2(0.45f, 0.0f), Vector2.down, rayLength, GroundLayer);
        if (!isIce && !isMud)
            if (leftCheckRay || rightCheckRay)
            {
                isGround = true;
                isIce = false;
                isMud = false;
            }
            else
            {
                isGround = false;
            }
        // Debug.Log(isGround);
    }

    public void CheckIsOnHorizontalIce()
    {
        RaycastHit2D leftCheckRay = CreateOffsetRaycast(new Vector2(-0.45f, 0.0f), Vector2.down, rayLength, IceLayer);
        RaycastHit2D rightCheckRay = CreateOffsetRaycast(new Vector2(0.45f, 0.0f), Vector2.down, rayLength, IceLayer);
        if ((!isGround && !isMud) || isIce)
        {
            if (leftCheckRay || rightCheckRay)
            {
                isIce = true;
                isGround = true;
            }
            else
            {
                isIce = false;
            }
        }


    }

    public void CheckIsOnHorizontalMud()
    {
        RaycastHit2D leftCheckRay = CreateOffsetRaycast(new Vector2(-0.45f, 0.0f), Vector2.down, rayLength, MudLayer);
        RaycastHit2D rightCheckRay = CreateOffsetRaycast(new Vector2(0.45f, 0.0f), Vector2.down, rayLength, MudLayer);
        if ((!isIce && !isGround) || isMud)
        {
            if (leftCheckRay || rightCheckRay)
            {
                isMud = true;
                isGround = true;
            }
            else
            {
                isMud = false;
            }
        }
    }

    void Update()
    {
        CheckCollision();
        // Debug.Log(isGround);
    }
}
