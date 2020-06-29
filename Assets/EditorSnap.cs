using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class EditorSnap : MonoBehaviour {
    
    [SerializeField] [Range(1f,20f)] float gridSize = 10f; //range restricts the range of the field

    TextMesh textMesh;

    private void Start()
    {
        
    }
    // Use this for initialization
    private void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / 10) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / 10) * gridSize;

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = snapPos.x/ gridSize + ", " + snapPos.z/gridSize;
        textMesh.text = labelText;
        gameObject.name = labelText;

    }
}
