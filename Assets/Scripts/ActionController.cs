using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    public Sprite[] pic;
    private int runCnt = 0;
    private float DELTA=0.01f;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    public void Stand()
    {
        sr.sprite = pic[0];
    }
    public void Run()
    {
        runCnt++;
        if (runCnt == 20)
        {
            if (rb.velocity.y > 0)
            {
                sr.sprite = pic[1];
            }
            else
            {
                sr.sprite = pic[2];
            }
        }
        else if(runCnt==40)
        {
            if (rb.velocity.y > 0)
            {
                sr.sprite = pic[3];
            }
            else
            {
                sr.sprite = pic[4];
            }
            runCnt = 0;
        }
    }
    public void Jump()
    {
        if (rb.velocity.y > 0)
        {
            sr.sprite = pic[5];
        }
        else
        {
            sr.sprite = pic[6];
        }
    }
    public void Dash()
    {
        if (rb.velocity.x > DELTA)
        {
            sr.sprite = pic[7]; 
        }
        else if (rb.velocity.x < -DELTA)
        {
            sr.sprite = pic[8];
        }
        else
        {
            sr.sprite = pic[9];
        }
    }
}
