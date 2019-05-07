using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    public Transform player1;
    public Transform player2;
    public Transform prismTransform;
    public Prism prism;

    public float spawnRate = 3f;

    private float lastTime;


    [SerializeField] private float radius;
    [SerializeField] private GameObject prefabAzul;
    [SerializeField] private GameObject prefabAmarillo;
    [SerializeField] private GameObject prefabRojo;
    [SerializeField] private GameObject prefabVioleta;
    [SerializeField] private GameObject prefabNaranja;
    [SerializeField] private GameObject prefabVerde;


    private void Start() {
        lastTime = Time.time;
    }

    public void SpawnRandom(){
        switch((int) Random.Range(1.0f, 6.0f)){
            case 1: Spawn("Azul");
                    break;
            case 2: Spawn("Amarillo");
                    break;
            case 3: Spawn("Rojo");
                    break;
            case 4: Spawn("Violeta");
                    break;
            case 5: Spawn("Verde");
                    break;
            case 6: Spawn("Naranja");
                    break;
        }
    }

    public void Spawn(string color){
        float randomAngle = Random.Range(0f, 360f);
        Vector2 spawnPosition = new Vector2(Mathf.Cos(randomAngle)*radius, Mathf.Sin(randomAngle)*radius);
        GameObject enemy = null;
        //Debug.Log("Spawning enemy at: " + spawnPosition);
        if(color == "Azul"){
            enemy = Instantiate(prefabAzul, spawnPosition, Quaternion.identity);
            if(prism.azulStrong) enemy.GetComponent<EnemyMovement>().setGoal( randomAngle >=180 ? player1 : player2);
            else enemy.GetComponent<EnemyMovement>().setGoal(prismTransform);
        }
        else if(color == "Amarillo"){
            enemy = Instantiate(prefabAmarillo, spawnPosition, Quaternion.identity);
            if(prism.amarilloStrong) enemy.GetComponent<EnemyMovement>().setGoal( randomAngle >=180 ? player1 : player2);
            else enemy.GetComponent<EnemyMovement>().setGoal(prismTransform);
        }
        else if(color == "Rojo"){
            enemy = Instantiate(prefabRojo, spawnPosition, Quaternion.identity);
            if(prism.rojoStrong) enemy.GetComponent<EnemyMovement>().setGoal( randomAngle >=180 ? player1 : player2);
            else enemy.GetComponent<EnemyMovement>().setGoal(prismTransform);
        }
        else{    
            if(color == "Violeta") enemy = Instantiate(prefabVioleta, spawnPosition, Quaternion.identity);
            else if(color == "Verde") enemy = Instantiate(prefabVerde, spawnPosition, Quaternion.identity);
            else if(color == "Naranja") enemy = Instantiate(prefabNaranja, spawnPosition, Quaternion.identity);
            if(enemy != null) enemy.GetComponent<EnemyMovement>().setGoal( randomAngle >=180 ? player1 : player2);
        }
    }

    //TODO: Eliminar
    private void Update() {
        if(Time.time >= lastTime + spawnRate){
            SpawnRandom();
            spawnRate *= 0.95f;
        }
    }
    
}
