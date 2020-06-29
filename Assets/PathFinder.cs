using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

	// Use this for initialization
	void Start () {
        LoadBlocks();
	}

    public void LoadBlocks()
    {
        var waypoints = FindObjectOfType<Waypoint>();

        foreach (Waypoint waypoint in waypoints)
        {
            grid.Add(waypoint.GetGridPos(), waypoint);
        }
        print(grid.Count);
    }
        // Update is called once per frame
	void Update () {
		
	}

    public IEnumerator<Waypoint> GetEnumerator()
    {
        return Waypoint.GetEnumerator();
    }

}
