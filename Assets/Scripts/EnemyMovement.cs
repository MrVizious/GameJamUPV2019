using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3.5f;
    [SerializeField] private Transform goal;

    public bool goingUp=true;
    private Animator anim;

    void Start()
    {
        anim=this.GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, goal.position, Time.deltaTime * speed);
        if(goal.position.y > transform.position.y) goingUp = true;
        else if(goal.position.y < transform.position.y) goingUp = false;
        if(goingUp)
        {
            anim.SetBool("Walk_Up",true);
        }
        else
        {
            anim.SetBool("Walk_Up",false);
        }
    }

    public void setGoal(Transform t){
        goal = t;
    }
}
