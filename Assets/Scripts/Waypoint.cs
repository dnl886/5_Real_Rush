using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    [SerializeField] Color exploredColor;
    //public is ok here as it is a data class

    public bool isExplored = false;
    public bool isPlaceable = true;
    [SerializeField] Tower towerPrefab;

    public Waypoint exploredFrom;
    Vector2Int gridPos;
    const int gridSize = 10;

	// Use this for initialization
	void Start () {
        Physics.queriesHitTriggers = true;
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

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) // left click
        {
            if (isPlaceable)
            {
                print(gameObject.name + " tower placement");
                Instantiate(towerPrefab, transform.position, Quaternion.identity);
                isPlaceable = false;
            }
            else
            {
                print("Can't place here");
            }
        }
    }





}
