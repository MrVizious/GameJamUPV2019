using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(LineRenderer))]
public class LaserScript : MonoBehaviour
{
    private BoxCollider2D collider;
    private LineRenderer line;
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        line = GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        Debug.Log("Raycast shooting!");
        // Cast a ray straight forward.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        Debug.DrawRay(transform.position, transform.up, Color.green, 2);
    }

}
