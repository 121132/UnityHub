using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetFloat("Attack", 1);
        }
        // 检查当前动画是否播放完
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0); // 获取当前动画状态信息，0 是层级索引
        if (stateInfo.IsName("Player_01_Attack") && stateInfo.normalizedTime >= 1f) // 判断是否是攻击动画且动画播放完
        {
            animator.SetFloat("Attack", 0); // 播放完毕后将 Attack 重置为 0
        }
    }
}
