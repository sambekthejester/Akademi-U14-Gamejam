using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_EnemySpawner : MonoBehaviour
{
    public Transform parent;
    public GameObject enemyPrefab;
    public Wizard_PlayerController player;
    public Transform[] spawnPoints;

    public float waitFor;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0.5f, waitFor);
    }

    private void Update()
    {
        if (player.isGameEnded)
        {
            CancelInvoke();
        }
    }

    private void SpawnEnemy()
    {
        int randPos = Random.Range(0, spawnPoints.Length);
        GameObject enemy = Instantiate(enemyPrefab, spawnPoints[randPos].position, Quaternion.identity, parent);
    }
}
