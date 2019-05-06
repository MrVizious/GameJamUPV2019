﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(LineRenderer))]
public class LaserScript : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 30f;
    [SerializeField] private GameObject otherPlayer;

    private BoxCollider2D collider;
    private LineRenderer line;
    private LayerMask mask;
    private LineRenderer secondaryLaser;

    private string firstColorName;
    private Color firstRayColor;
    private Color secondRayColor;
    private string otherRayColor;

    void Start()
    {
        mask = tag == "Laser1" ? 1 << LayerMask.NameToLayer("Laser2") : 1 << LayerMask.NameToLayer("Laser1");
        collider = GetComponent<BoxCollider2D>();
        line = GetComponent<LineRenderer>();
        secondaryLaser = transform.Find("SecondaryLaser").gameObject.GetComponent<LineRenderer>();
        secondaryLaser.enabled=false;
    }

    private void Update()
    {
    	if(transform.parent.gameObject.GetComponent<PlayerController>().getShoot())
    	{
			Shoot();
    	}else
    	{
    		secondaryLaser.enabled=false;
    		this.gameObject.GetComponent<LineRenderer>().enabled=false;
			this.gameObject.GetComponent<BoxCollider2D>().enabled=false;
    	}
    }

    private void Shoot()
    {
        // Cast a ray straight forward.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, raycastDistance, mask);
        Debug.DrawRay(transform.position, transform.up * 30f, Color.green, 0.2f);
        setFirstRayColor();
        line.SetColors(firstRayColor,firstRayColor);
        if (hit.collider != null)
        {
            //secondaryLaser.SetActive(true);
            MergeLaser(hit);
        }
        else
        {
        	secondaryLaser.enabled=false;
        	line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position + transform.up * 30f);
    		this.gameObject.GetComponent<LineRenderer>().enabled=true;
    		this.gameObject.GetComponent<BoxCollider2D>().enabled=true;
        }
    }

    private void MergeLaser(RaycastHit2D hit)
    {
    	mixColors();
        //Debug.Log("Transform up: "+ transform.up);
        //Debug.Log("Distance: "+ Vector2.Distance(transform.parent.transform.position,hit.point));
        //Debug.Log(hit.point);
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hit.point);
        this.gameObject.GetComponent<LineRenderer>().enabled=true;
    	this.gameObject.GetComponent<BoxCollider2D>().enabled=true;

    	secondaryLaser.SetPosition(0, hit.point);
		secondaryLaser.SetPosition(1, transform.position + transform.up * 30f);
		secondaryLaser.SetColors(secondRayColor,secondRayColor);
        secondaryLaser.enabled=true;
    	
        //Debug.Log("MergeLaser from: " + tag);
    }

    private void setFirstRayColor()
    {
    	firstColorName=transform.parent.gameObject.GetComponent<PlayerCharacter>().getCurrentColor();
    	switch(firstColorName){
    		case "Cian":
    			firstRayColor = Color.cyan;
    			break;
    		case "Magenta":
    			firstRayColor = Color.magenta;
    			break;
    		case "Amarillo":
    			firstRayColor = Color.yellow;
    			break;
    	}
    }

    private void mixColors()
    {
    	otherRayColor = otherPlayer.GetComponent<PlayerCharacter>().getCurrentColor();

    	if(otherRayColor==firstColorName)
    	{
    		secondRayColor=firstRayColor;
    	}
    	else if((otherRayColor == "Cian" && firstColorName=="Magenta")||(otherRayColor == "Magenta" && firstColorName=="Cian"))
    	{
    		secondRayColor = new Color(1,1,1,1);
    	}
    	else if((otherRayColor == "Cian" && firstColorName=="Amarillo")||(otherRayColor == "Amarillo" && firstColorName=="Cian"))
    	{
    		secondRayColor = new Color(1,1,1,1);
    	}
    	else if((otherRayColor == "Amarillo" && firstColorName=="Magenta")||(otherRayColor == "Magenta" && firstColorName=="Amarillo"))
    	{
    		secondRayColor = new Color(1,1,1,1);
    	}

    }

}

