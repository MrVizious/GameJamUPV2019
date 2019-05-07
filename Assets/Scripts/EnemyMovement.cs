using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3.5f;
    [SerializeField] private Transform goal;

    public bool goingUp;

    
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, goal.position, Time.deltaTime * speed);
        if(goal.position.y > transform.position.y) goingUp = true;
        else if(goal.position.y < transform.position.y) goingUp = false;
    }

    public void setGoal(Transform t){
        goal = t;
    }
}
