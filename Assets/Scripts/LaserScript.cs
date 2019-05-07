using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(LineRenderer))]
public class LaserScript : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 30f;
    [SerializeField] private GameObject otherPlayer;
    [SerializeField] private float alpha;
    [SerializeField] private float dischargeRate = 5f;
    [SerializeField] private float chargeRate = 3.5f;
    [SerializeField] private GameObject filledBar;


    private BoxCollider2D collider;
    private LineRenderer line;
    private LayerMask mask;
    private LayerMask maskEnemies;
    private LineRenderer secondaryLaser;

    private string firstColorName;
    private string secondColorName;
    private Color firstRayColor;
    private Color secondRayColor;
    private string otherRayColor;

    private float percentageLoad = 100f;
    private bool canShoot = true;

    private float scaleXIni=0.38f;

    void Start()
    {
        mask = tag == "Laser1" ? 1 << LayerMask.NameToLayer("Laser2") : 1 << LayerMask.NameToLayer("Laser1");
        maskEnemies = 1 << LayerMask.NameToLayer("Enemy");
        collider = GetComponent<BoxCollider2D>();
        line = GetComponent<LineRenderer>();
        secondaryLaser = transform.Find("SecondaryLaser").gameObject.GetComponent<LineRenderer>();
        secondaryLaser.enabled=false;
    }

    private void Update()
    {
        
    	if(transform.parent.gameObject.GetComponent<PlayerController>().getShoot() && canShoot)
    	{
			Shoot();
    	}else
    	{
            percentageLoad += chargeRate * Time.deltaTime;
            percentageLoad = Mathf.Clamp(percentageLoad, 0f, 100f);
            if(!canShoot && percentageLoad == 100f) canShoot = true;

    		secondaryLaser.enabled=false;
    		this.gameObject.GetComponent<LineRenderer>().enabled=false;
			this.gameObject.GetComponent<BoxCollider2D>().enabled=false;
    	}
        filledBar.transform.localScale=new Vector2((scaleXIni * percentageLoad) /100f,0.186208f);

    }

    private void Shoot()
    {
        percentageLoad -= dischargeRate * Time.deltaTime;
        percentageLoad = Mathf.Clamp(percentageLoad, 0f, 100f);
        if(percentageLoad == 0f){
            canShoot = false;
        }

        Debug.Log("Empezando a disparar");

        // Raycast de láser
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, raycastDistance, mask);

        // Rayo de daño a los enemigos
        RaycastHit2D hitEnemies = Physics2D.Raycast(transform.position, transform.up, raycastDistance, maskEnemies);

        setFirstRayColor();
        line.SetColors(firstRayColor,firstRayColor);

        //Encuentra tanto láser como enemigo
        if(hitEnemies.collider != null){
            if(hit.collider !=null){
                //Si encuentra antes el enemigo que el láser
                if(Vector2.Distance(transform.position, hitEnemies.point) < Vector2.Distance(transform.position, hit.point) ){
                    Debug.Log("Ha encontrado a un enemigo antes que a un láser");
                    secondaryLaser.enabled=false;
                    line.SetPosition(0, transform.position);
                    line.SetPosition(1, transform.position + transform.up * Vector2.Distance(transform.position, hitEnemies.point));
                    this.gameObject.GetComponent<LineRenderer>().enabled=true;
                    this.gameObject.GetComponent<BoxCollider2D>().enabled=true;
                }
                //Si encuentra antes el láser que el enemigo
                else {
                    Debug.Log("Ha encontrado a un láser antes que a un enemigo");
                    MergeLaser(hit);
                    secondaryLaser.SetPosition(1, hitEnemies.point);
                    hitEnemies.collider.gameObject.GetComponent<EnemyCharacter>().Hurt(secondColorName);
                }
            }
            //Si sólo encuentra un enemigo
            else{
                Debug.Log("Ha encontrado sólo un enemigo");
                secondaryLaser.enabled=false;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, transform.position + transform.up * Vector2.Distance(transform.position, hitEnemies.point));
                this.gameObject.GetComponent<LineRenderer>().enabled=true;
                this.gameObject.GetComponent<BoxCollider2D>().enabled=true;
                
                hitEnemies.collider.gameObject.GetComponent<EnemyCharacter>().Hurt(firstColorName);
            }
        }
        //Si sólo encuentra un láser
        else if(hit.collider != null){
            Debug.Log("Sólo ha encontrado un láser");
            MergeLaser(hit);
        }

        else if(hit.collider == null || hitEnemies.collider == null){
            Debug.Log("No ha encontrado nada");
            secondaryLaser.enabled=false;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position + transform.up * raycastDistance);
            this.gameObject.GetComponent<LineRenderer>().enabled=true;
            this.gameObject.GetComponent<BoxCollider2D>().enabled=true;

        }

        // LAS ANTIGUAS ESCRITURAS HACEN QUE ESTE CÓDIGO FUNCIONE AUNQUE SIN COLISIONES, NO LO JODAS TÚ, POBRE MORTAL
        /*
        Debug.DrawRay(transform.position, transform.up * raycastDistance, Color.green, 0.2f);
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
            line.SetPosition(1, transform.position + transform.up * raycastDistance);
    		this.gameObject.GetComponent<LineRenderer>().enabled=true;
    		this.gameObject.GetComponent<BoxCollider2D>().enabled=true;
        }
        */
        // DE AQUÍ PARA ABAJO YA SON ESCRITURAS ALGO MENOS SAGRADAS
        
        
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
		secondaryLaser.SetPosition(1, transform.position + transform.up * raycastDistance);
		secondaryLaser.SetColors(secondRayColor,secondRayColor);
        secondaryLaser.enabled=true;
    	
        //Debug.Log("MergeLaser from: " + tag);
    }

    private void setFirstRayColor()
    {
    	firstColorName=transform.parent.gameObject.GetComponent<PlayerCharacter>().getCurrentColor();
    	switch(firstColorName){
    		case "Azul":
    			firstRayColor = new Color(0,0,1,alpha);
    			break;
    		case "Rojo":
    			firstRayColor = new Color(1,0,0,alpha);
    			break;
    		case "Amarillo":
    			firstRayColor = new Color(1,1,0,alpha);
    			break;
    	}
    }

    private void mixColors()
    {
    	otherRayColor = otherPlayer.GetComponent<PlayerCharacter>().getCurrentColor();

    	if(otherRayColor==firstColorName)
    	{
    		secondRayColor=firstRayColor;
            secondColorName = firstColorName;
    	}
    	else if((otherRayColor == "Azul" && firstColorName=="Rojo")||(otherRayColor == "Rojo" && firstColorName=="Azul"))
    	{//Purpura
    		secondRayColor = new Color(1,0,1,alpha);
            secondColorName = "Violeta";
    	}
    	else if((otherRayColor == "Azul" && firstColorName=="Amarillo")||(otherRayColor == "Amarillo" && firstColorName=="Azul"))
    	{//Verde
    		secondRayColor = new Color(0,1,0,alpha);
            secondColorName = "Verde";
    	}
    	else if((otherRayColor == "Amarillo" && firstColorName=="Rojo")||(otherRayColor == "Rojo" && firstColorName=="Amarillo"))
    	{//Naranja
    		secondRayColor = new Color(1,0.5f,0,alpha);
            secondColorName = "Naranja";
    	}

    }

}

