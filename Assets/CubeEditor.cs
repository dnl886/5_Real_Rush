using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour {
    
    const int  gridSize = 10; //range restricts the range of the field
    Vector3 gridPos;

    Waypoint waypoint;
    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }
    private void Start()
    {
        
    }
    // Use this for initialization
    private void Update()
    {
        SnapToGrid();
        UpdateLabel();

    }
    void SnapToGrid()
    {
        int gridSize = waypoint.getGridSize();


        transform.position = new Vector3(
            waypoint.GetGridPos().x,
            0f,
            waypoint.GetGridPos().y
            );
    }

    void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        int gridSize = waypoint.getGridSize();
        string labelText = 
            waypoint.GetGridPos().x / gridSize +  // getting position of cubes from the way point script
            ", " + 
            waypoint.GetGridPos().y / gridSize;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
