using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    public Transform player1;
    public Transform player2;
    public Transform prism;


    [SerializeField] private float radius;
    [SerializeField] private GameObject prefabAzul;
    [SerializeField] private GameObject prefabAmarillo;
    [SerializeField] private GameObject prefabRojo;
    [SerializeField] private GameObject prefabVioleta;
    [SerializeField] private GameObject prefabNaranja;
    [SerializeField] private GameObject prefabVerde;

    //Azul, amarillo, rojo
    private bool[] strongColors = {false, false, false};

    public void SpawnRandom(){

    }

    public void Spawn(string color){
        float randomAngle = Random.Range(0f, 360f);
        Vector2 spawnPosition = new Vector2(Mathf.Cos(randomAngle)*radius, Mathf.Sin(randomAngle)*radius);
        Debug.Log("Spawning enemy at: " + spawnPosition);
        if(color == "Azul"){
            GameObject enemy = Instantiate(prefabAzul, spawnPosition, Quaternion.identity);
            if(strongColors[0]) enemy.GetComponent<EnemyMovement>().setGoal( randomAngle >=180 ? player1 : player2);
            else enemy.GetComponent<EnemyMovement>().setGoal(prism);
        }
        if(color == "Amarillo"){
            GameObject enemy = Instantiate(prefabAmarillo, spawnPosition, Quaternion.identity);
            if(strongColors[1]) enemy.GetComponent<EnemyMovement>().setGoal( randomAngle >=180 ? player1 : player2);
            else enemy.GetComponent<EnemyMovement>().setGoal(prism);
        }
        if(color == "Rojo"){
            GameObject enemy = Instantiate(prefabRojo, spawnPosition, Quaternion.identity);
            if(strongColors[2]) enemy.GetComponent<EnemyMovement>().setGoal( randomAngle >=180 ? player1 : player2);
            else enemy.GetComponent<EnemyMovement>().setGoal(prism);
        }
    }

    //TODO: Eliminar
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) Spawn("Rojo");
    }
    
}
