using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] int towerLimit = 8;
    [SerializeField] Tower towerPrefab;
    bool isPlaceable;

    Queue<Tower> towerQueue = new Queue<Tower>();

    
    
    public void AddTower(Waypoint baseWaypoint)
    {
        int numTowers = towerQueue.Count;

        if(numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }
    

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceable = false;

        towerQueue.Enqueue(newTower); /////probably vdelete
    }
    void MoveExistingTower(Waypoint baseWaypoint)
    {
        print("Tower Limit Reached!!");
        //take bottom tower off queue
        var oldTower = towerQueue.Dequeue();

        //set the isPlaceable
        //set the base waypoints

        //put the old tower on the top of the queue
        towerQueue.Enqueue(oldTower);
    }
}
