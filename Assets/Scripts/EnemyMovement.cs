using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    
    [SerializeField] List<Waypoint> path; //so we cans see it
    [Range(0f, 10f)][SerializeField] float dwellTime = 1f;
    // Use this for initialization
    // Use this for initialization
    void Start()
    {
        PathFinder pathfinder = FindObjectOfType<PathFinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting patrol...");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(2f);
        }
        print("Ending patrol");
    }

}
