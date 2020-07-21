using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] int towerLimit = 8;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTransform;
    //bool isPlaceable;

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
        newTower.transform.parent = towerParentTransform;
        baseWaypoint.isPlaceable = false;

        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;

        towerQueue.Enqueue(newTower); /////probably vdelete
    }
    void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        print("Tower Limit Reached!!");
        //take bottom tower off queue
        var oldTower = towerQueue.Dequeue();

        //set the isPlaceable
        oldTower.baseWaypoint.isPlaceable = true; // the tower we once used is placeable again

        //set the base waypoints
        newBaseWaypoint.isPlaceable = false; //current one is now unplaceable

        oldTower.baseWaypoint = newBaseWaypoint;

        oldTower.transform.position = newBaseWaypoint.transform.position; // we actually move the tower now

        //put the old tower on the top of the queue
        towerQueue.Enqueue(oldTower);
    }
}
