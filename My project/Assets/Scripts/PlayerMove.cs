using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb2d;
    public float MoveSpeed = 0.4f;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        // 获取水平轴
        float horizontal = Input.GetAxisRaw("Horizontal");
        // 获取垂直轴
        float vertical = Input.GetAxisRaw("Vertical");
        // Debug.Log(horizontal);
        // 按下左或右
        if (horizontal == 1)
        {
            animator.SetFloat("Horizontal", horizontal);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (horizontal == -1)
        {
            animator.SetFloat("Horizontal", horizontal);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        // 切换move动作
        Vector2 movement = new Vector2(horizontal, vertical);
        animator.SetFloat("Speed", movement.magnitude);
        // 朝该方向移动
        rb2d.velocity = movement * MoveSpeed;
    }
}
