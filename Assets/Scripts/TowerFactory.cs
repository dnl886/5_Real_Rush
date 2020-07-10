using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] int towerLimit = 8;
    [SerializeField] Tower towerPrefab;
    bool isPlaceable;

    Queue<Tower> queue = new Queue<Tower>();
    
    public void AddTower(Waypoint baseWaypoint)
    {
        var towers = FindObjectsOfType<Tower>();
        int numTowers = towers.Length;

        if(numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void MoveExistingTower(Waypoint baseWayPoint)
    {
        print("Tower Limit Reached!");
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceable = false;

        queue.Enqueue(towerPrefab);
    }
}
