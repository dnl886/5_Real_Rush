using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    [SerializeField] Waypoint startWayPoint, endWayPoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    Queue<Waypoint> queue = new Queue<Waypoint>();

    [SerializeField]bool isRunning = true;

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left

    };

    // Use this for initialization
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        PathFind();
        //ExploreNeighbors()
;    }

    void PathFind()
    {
        queue.Enqueue(startWayPoint); //starting waypoint is the fist in the queue

        while (queue.Count > 0 && isRunning)
        {
            var searchCenter = queue.Dequeue();
            print("Searching from: " + searchCenter);

            HaltIfEndFound(searchCenter);
            ExploreNeighbors(searchCenter);
            searchCenter.isExplored = true;
        }

        print("Finnished pathfinding?");
    }

    void HaltIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == endWayPoint)
        {
            print("Searching from end node, therefore stopping");
            isRunning = false;
        }
    }
    void ExploreNeighbors(Waypoint from)
    {

        if (!isRunning) { return; }
        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighborCoordinates = from.GetGridPos() + direction;
            try
            {
                QueueNewNeighbors(neighborCoordinates);
            }
            catch
            {
                //do nothing
            }
        }
    }

    void QueueNewNeighbors(Vector2Int neighborCoordinates)
    {
        Waypoint neighbor = grid[neighborCoordinates]; //try to find neighbors from our dictionary
        if (neighbor.isExplored)
        {
            //do nothing
        }
        else
        {
            neighbor.SetTopColor(Color.blue); // set their colors to blue
            queue.Enqueue(neighbor);//the neighbors are now at the front of the queue
            print("Queueing " + neighbor);
        }
        
    }

    //useless rn
    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Overlapping block at: " + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint); //if accessing settopcolor color.black you have to define it in the parameters
            }
        }
        print("Loaded " + grid.Count + " blocks");
    }

    void ColorStartAndEnd()
    {
        startWayPoint.SetTopColor(Color.green);
        endWayPoint.SetTopColor(Color.red);
    }

}
