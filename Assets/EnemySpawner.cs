using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawn = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(SpawnEnemies());
	}

    IEnumerator SpawnEnemies()
    {
        while (true) //forever
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            print("spawning");
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }
}
