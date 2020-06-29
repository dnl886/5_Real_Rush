using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] List<Waypoint> path;
    [SerializeField] float dwellTime = 1f;
	// Use this for initialization
	void Start () {
        StartCoroutine(FollowPath());
        print("Hey i'm back at the start");
	}
	IEnumerator FollowPath()
    {
        print("Starting patrol.. ");
        foreach (Waypoint wayPoint in path)
        {
            transform.position = wayPoint.transform.position; //will move where the waypoint resides every 1 seconds
            print("Visiting block: " + wayPoint.name);
            yield return new WaitForSeconds(dwellTime);

        }
        print("Ending patrol ");
    }
	
}
