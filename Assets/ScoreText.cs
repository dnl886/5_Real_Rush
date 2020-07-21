using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {
    [SerializeField] List<EnemyMovement> enemyPrefab = new List<EnemyMovement>();
    [SerializeField] Text scoreText;
    [SerializeField] int score = 0;
    [SerializeField] int enemyScoreMultiplier = 1;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = score.ToString();
        foreach(EnemyMovement enemies in enemyPrefab)
        {
            score += enemyScoreMultiplier;
        }
	}
}
