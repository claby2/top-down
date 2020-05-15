using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour {

    public Transform target;
    public GameObject PlayerVisualEffect;
    public VisualEffectBehavior visualEffectBehavior;
    public GameObject[] enemies;
    public float spawnArea;

    void Start() {
        for(int i = 0; i < enemies.Length; i++) {
            Vector3 spawnPosition = transform.position;
            spawnPosition.x = Random.Range(transform.position.x - (spawnArea / 2), transform.position.x + (spawnArea / 2));
            spawnPosition.y = Random.Range(transform.position.y - (spawnArea / 2), transform.position.y + (spawnArea / 2));
            GameObject enemy = Instantiate(enemies[i], spawnPosition, Quaternion.identity);
            enemy.GetComponent<EnemyBehavior>().target = target;
            enemy.GetComponent<EnemyBehavior>().PlayerVisualEffect = PlayerVisualEffect;
            enemy.GetComponent<EnemyBehavior>().visualEffectBehavior = visualEffectBehavior;
        }
    }
}
