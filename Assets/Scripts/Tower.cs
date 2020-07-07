using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;

    [SerializeField] GameObject towerGun;

    bool isMoving;
    
	
	void Update () {
        objectToPan.LookAt(targetEnemy);
	}

    

}
