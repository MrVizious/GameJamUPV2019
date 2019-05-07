using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    public Transform player1;
    public Transform player2;
    public Transform prismTransform;

    public Prism prism;


    [SerializeField] private float radius;
    [SerializeField] private GameObject prefabAzul;
    [SerializeField] private GameObject prefabAmarillo;
    [SerializeField] private GameObject prefabRojo;
    [SerializeField] private GameObject prefabVioleta;
    [SerializeField] private GameObject prefabNaranja;
    [SerializeField] private GameObject prefabVerde;

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
        //Debug.Log("Spawning enemy at: " + spawnPosition);
        if(color == "Azul"){
            GameObject enemy = Instantiate(prefabAzul, spawnPosition, Quaternion.identity);
            if(prism.azulStrong) enemy.GetComponent<EnemyMovement>().setGoal( randomAngle >=180 ? player1 : player2);
            else enemy.GetComponent<EnemyMovement>().setGoal(prismTransform);
        }
        else if(color == "Amarillo"){
            GameObject enemy = Instantiate(prefabAmarillo, spawnPosition, Quaternion.identity);
            if(prism.amarilloStrong) enemy.GetComponent<EnemyMovement>().setGoal( randomAngle >=180 ? player1 : player2);
            else enemy.GetComponent<EnemyMovement>().setGoal(prismTransform);
        }
        else if(color == "Rojo"){
            GameObject enemy = Instantiate(prefabRojo, spawnPosition, Quaternion.identity);
            if(prism.rojoStrong) enemy.GetComponent<EnemyMovement>().setGoal( randomAngle >=180 ? player1 : player2);
            else enemy.GetComponent<EnemyMovement>().setGoal(prismTransform);
        }
        else{    
            if(color == "Violeta") GameObject enemy = Instantiate(prefabVioleta, spawnPosition, Quaternion.identity);
            else if(color == "Verde") GameObject enemy = Instantiate(prefabVerde, spawnPosition, Quaternion.identity);
            else if(color == "Naranja") GameObject enemy = Instantiate(prefabNaranja, spawnPosition, Quaternion.identity);
            enemy.GetComponent<EnemyMovement>().setGoal( randomAngle >=180 ? player1 : player2);
        }
    }

    //TODO: Eliminar
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) Spawn("Rojo");
    }
    
}
