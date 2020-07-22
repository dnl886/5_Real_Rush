using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour {

    [SerializeField] GameObject collisionMesh;
    [SerializeField] int hitPoints;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip hitSFX;
    [SerializeField] AudioClip deathSFX;

    AudioSource myAudioSource;
    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    private void OnParticleCollision(GameObject other)
    {
        GetComponent<AudioSource>().PlayOneShot(hitSFX);
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
        myAudioSource.PlayOneShot(hitSFX);
    }

    void KillEnemy()
    {
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        
        Destroy(vfx.gameObject, vfx.main.duration);
        AudioSource.PlayClipAtPoint(deathSFX, transform.position);
        Destroy(gameObject);

    }
}
