using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int lives = 3;

    [SerializeField] private KeyCode moveForward;
    [SerializeField] private KeyCode moveBackward;
    [SerializeField] private KeyCode moveRight;
    [SerializeField] private KeyCode moveLeft;



    public float speedRotation = 250;
    public float speedForward = 5;

    // Update is called once per frame
    void Update()
    {
        //Forward Movement
        if (Input.GetKey(moveForward))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speedForward);


        }
        else if (Input.GetKey(moveBackward))
        {
            transform.Translate(Vector3.up * Time.deltaTime * -speedForward);


        }
        //Horizontal Rotation

        if (Input.GetKey(moveRight))
        {
            transform.Rotate(new Vector3(0, 0, -speedRotation * Time.deltaTime));
        }
        else if (Input.GetKey(moveLeft))
        {
            transform.Rotate(new Vector3(0, 0, speedRotation * Time.deltaTime));
        }

    }
}
