using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour {

    [SerializeField] GameObject collisionMesh;
    [SerializeField] int hitPoints;
	// Use this for initialization
	void Start () {
		
	}

    private void OnParticleCollision(GameObject other)
    {
        print("I'm hit");
        ProcessHit();
        if (hitPoints <= 1)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        print("Current Hitpoints are: " + hitPoints);
    }

    void KillEnemy()
    {
        Destroy(gameObject);
    }
}
