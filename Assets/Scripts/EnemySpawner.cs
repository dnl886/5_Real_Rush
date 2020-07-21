using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;

    [SerializeField] Transform enemyParentTransform;

    [SerializeField] Text spawnedEnemies;
    [SerializeField] int score = 0;
    [SerializeField] int enemyScoreMultiplier = 1;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
        spawnedEnemies.text = score.ToString();
	}
	
    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) // forever
        {
            AddScore();
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    void AddScore()
    {
        score++;
        spawnedEnemies.text = score.ToString();
    }
}
