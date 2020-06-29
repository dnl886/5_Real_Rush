using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] List<Block> path;
    [SerializeField] float dwellTime = 1f;
	// Use this for initialization
	void Start () {
        StartCoroutine(FolloPath());
        print("Hey i'm back at the start");
	}
	IEnumerator FolloPath()
    {
        print("Starting patrol.. ");
        foreach (Block wayPoint in path)
        {
            transform.position = wayPoint.transform.position; //will move where the waypoint resides every 1 seconds
            print("Visiting block: " + wayPoint.name);
            yield return new WaitForSeconds(dwellTime);

        }
        print("Ending patrol ");
    }
	// Update is called once per frame
	void Update () {
		
	}
}
