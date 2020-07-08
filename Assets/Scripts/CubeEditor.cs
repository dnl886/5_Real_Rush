using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour {
    
    [Range(0f, 100f)][SerializeField] float  gridSize = 10; //range restricts the range of the field
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
            waypoint.GetGridPos().x * gridSize,
            0f,
            waypoint.GetGridPos().y * gridSize
            );
    }

    void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        int gridSize = waypoint.getGridSize();
        string labelText = 
            waypoint.GetGridPos().x +  // getting position of cubes from the way point script
            ", " + 
            waypoint.GetGridPos().y ;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }

    void SetStartColor(Color color)
    {
        var startColor = transform.Find("0,0").GetComponent<MeshRenderer>();
        startColor.material.color = color;
    }

    void SetEndColor(Color color)
    {
        var startColor = transform.Find("0,0").GetComponent<MeshRenderer>();
        startColor.material.color = color;
    }
    
}
