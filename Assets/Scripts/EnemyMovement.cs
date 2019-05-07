using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3.5f;
    [SerializeField] private Transform goal;

    
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, goal.position, Time.deltaTime * speed);
    }

    public void setGoal(Transform t){
        goal = t;
    }
}
