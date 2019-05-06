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
        Shoot();
    }

    private void Shoot()
    {
        // Cast a ray straight forward.
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, transform.up);
        //Debug.DrawRay(transform.position, transform.up, Color.green, 2);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null)
            {
                if ((hit.collider.gameObject.tag == "Laser2" && this.tag == "Laser1") ||
                    (hit.collider.gameObject.tag == "Laser1" && this.tag == "Laser2"))
                {
                    MergeLaser();
                }
            }
        }
    }

    private void MergeLaser()
    {
        Debug.Log("MergeLaser from: " + tag);
    }
}
