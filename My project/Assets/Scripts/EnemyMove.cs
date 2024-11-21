using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 0.2f; // 敌人的移动速度

    private void Update()
    {
        // 让敌人向左移动
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}
