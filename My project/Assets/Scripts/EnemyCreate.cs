using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour
{
    public GameObject enemy01_walk_left; // 史莱姆1号左走
    private float timeCounter = 0; // 控制时间

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >= 3)
        {
            // 生成随机位置
            float randomX = Random.Range(-8.5f, 8.5f);
            float randomY = Random.Range(-4.5f, 4.5f);
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

            GameObject enemyInstance = Instantiate(enemy01_walk_left, spawnPosition, Quaternion.identity);
            if (enemyInstance.GetComponent<EnemyMove>() == null) {
                enemyInstance.AddComponent<EnemyMove>();
            }
            timeCounter = 0; 
        }
    }
}
