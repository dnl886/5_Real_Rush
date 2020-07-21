using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour {

    [SerializeField] GameObject collisionMesh;
    [SerializeField] int hitPoints;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
	// Use this for initialization
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
        hitParticlePrefab.Play();
    }

    void KillEnemy()
    {
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();

        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);

    }
}
