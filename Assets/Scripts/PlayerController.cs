using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private KeyCode moveForward;
    [SerializeField] private KeyCode moveBackward;
    [SerializeField] private KeyCode moveRight;
    [SerializeField] private KeyCode moveLeft;
    [SerializeField] private KeyCode shootKey;
    [SerializeField] private KeyCode swapColor;
    [SerializeField] private GameObject spritePlayer;
    private  Animator anim;

    private GameObject laser;
    private bool shoot;



    public float speedRotation = 250;
    public float speedForward = 5;
    private float angle=90;

    private void Start()
    {
        laser = transform.Find("Laser").gameObject;
        shoot=false;
        anim=spritePlayer.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Forward Movement
        if (Input.GetKey(moveForward))
        {
            transform.Translate(Vector2.up * Time.deltaTime * speedForward);


        }
        else if (Input.GetKey(moveBackward))
        {
            transform.Translate(Vector2.up * Time.deltaTime * -speedForward);


        }
        //Horizontal Rotation

        if (Input.GetKey(moveRight))
        {
            transform.Rotate(new Vector3(0, 0, -speedRotation * Time.deltaTime));
            angle+=-speedRotation * Time.deltaTime;
        }
        else if (Input.GetKey(moveLeft))
        {
            transform.Rotate(new Vector3(0, 0, speedRotation * Time.deltaTime));
            angle+= speedRotation * Time.deltaTime;
        }

        if (Input.GetKey(shootKey))
        {
            shoot=true;
        }
        else
        {
            shoot=false;
        }

        if(Input.GetKeyDown(swapColor))
        {
            this.gameObject.GetComponent<PlayerCharacter>().nextColor();
        }

        spritePlayer.transform.position=this.transform.position;

        if(angle < 0){angle = 360+angle;}
        else if(angle>=360){angle=angle-360;}


        if(angle <= 45 || angle > 360-45)
        {
            anim.SetInteger("Direction",0);
        }
        else if(angle > 45 && angle <= 135)
        {
            anim.SetInteger("Direction",1);
        }
        else if(angle > 135 && angle <= 225)
        {
            anim.SetInteger("Direction",2);
        }
        else if(angle > 225 && angle <= 315)
        {
            anim.SetInteger("Direction",3);
        }

    }

    public bool getShoot(){return shoot;}

}
