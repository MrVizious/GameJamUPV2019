using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    public float health = 1f;
    public float damage = 1.5f;
    public string color;

    public void Hurt(string rayColor){
        if(rayColor == color) health -= damage * Time.deltaTime;
        if(health <= 0f) Die();
        //Debug.Log("Life: "+ health);
    }

    public void Die(){
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") other.GetComponent<PlayerCharacter>().Hurt();
        else if(other.tag == "Prism") other.GetComponent<Prism>().addColor(color);
        Die();
    }
}
