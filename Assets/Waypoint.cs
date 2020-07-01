using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    Vector2Int gridPos;
    const int gridSize = 10;
	// Use this for initialization
	void Start () {
		
	}
    public int getGridSize()
    {
        return gridSize;
    }
	
    public Vector2Int GetGridPos()
    {

        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / 10) ,
            Mathf.RoundToInt(transform.position.z / 10) 
        );
    }
	

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
    

    
}
