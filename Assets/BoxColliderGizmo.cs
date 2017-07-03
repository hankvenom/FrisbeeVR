using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderGizmo : MonoBehaviour
{
    public BoxCollider colliderToHighlight;
    public Color colorToAssign=Color.red;
    // Use this for initialization
    void Start()
    {
        if (colliderToHighlight == null)
            colliderToHighlight = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        if (colliderToHighlight == null)
            colliderToHighlight = GetComponent<BoxCollider>();
        Gizmos.color = colorToAssign;
    
        Gizmos.DrawCube(colliderToHighlight.transform.position, colliderToHighlight.size);
    }
}
