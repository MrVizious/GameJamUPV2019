using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(LineRenderer))]
public class LaserScript : MonoBehaviour
{
    [SerializeField]
    private float raycastDistance = 30f;
    private BoxCollider2D collider;
    private LineRenderer line;
    private LayerMask mask;
    private GameObject secondaryLaser;
    void Start()
    {
        mask = tag == "Laser1" ? 1 << LayerMask.NameToLayer("Laser2") : 1 << LayerMask.NameToLayer("Laser1");
        collider = GetComponent<BoxCollider2D>();
        line = GetComponent<LineRenderer>();
        secondaryLaser = transform.Find("SecondaryLaser").gameObject;
        secondaryLaser.GetComponent<LineRenderer>().enabled=false;
    }

    private void Update()
    {
    	if(transform.parent.gameObject.GetComponent<PlayerController>().getShoot())
    	{
			Shoot();
    	}else
    	{
    		secondaryLaser.GetComponent<LineRenderer>().enabled=false;
    		this.gameObject.GetComponent<LineRenderer>().enabled=false;
			this.gameObject.GetComponent<BoxCollider2D>().enabled=false;
    	}
    }

    private void Shoot()
    {
        // Cast a ray straight forward.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, raycastDistance, mask);
        Debug.DrawRay(transform.position, transform.up * 30f, Color.green, 0.2f);
        if (hit.collider != null)
        {
            //secondaryLaser.SetActive(true);
            MergeLaser(hit);
        }
        else
        {
        	secondaryLaser.GetComponent<LineRenderer>().enabled=false;
        	line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position + transform.up * 30f);
    		this.gameObject.GetComponent<LineRenderer>().enabled=true;
    		this.gameObject.GetComponent<BoxCollider2D>().enabled=true;
        }
    }

    private void MergeLaser(RaycastHit2D hit)
    {
        //Debug.Log("Transform up: "+ transform.up);
        //Debug.Log("Distance: "+ Vector2.Distance(transform.parent.transform.position,hit.point));
        //Debug.Log(hit.point);
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hit.point);
        this.gameObject.GetComponent<LineRenderer>().enabled=true;
    	this.gameObject.GetComponent<BoxCollider2D>().enabled=true;

    	secondaryLaser.GetComponent<LineRenderer>().SetPosition(0, hit.point);
		secondaryLaser.GetComponent<LineRenderer>().SetPosition(1, transform.up*30f);
        secondaryLaser.GetComponent<LineRenderer>().enabled=true;
    	
        //Debug.Log("MergeLaser from: " + tag);
    }
}
