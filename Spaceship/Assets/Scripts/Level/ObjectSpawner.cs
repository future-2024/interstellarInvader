using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{

    //variable for position, which will be used for calculating random position between two points
    public Transform RightPosition;
    //delay between spawns
    public float spawnDelay;
    //array for prefabs, which should be spawn
    public GameObject[] Item;
    private Score score;
    //will be executed once at start
    void Start()
    {
        score = GameObject.Find("ScoreManger").GetComponent<Score>();
        
        //"Spawn" function will be called repeatedly
        InvokeRepeating("Spawn", 5, spawnDelay);
         
    }

    //spawn function
    void Spawn()
    {
        if (score.winBool == false)
        {
            //calculate random position between AsteroidSpawner and RighPosition
            Vector3 spawnPos = new Vector3(Random.Range(transform.position.x, RightPosition.position.x), transform.position.y, 0);
            //calculate random variable i between 0 and array length (number of members)
            int i = Random.Range(0, Item.Length);
            //place prefab at calculated position
            Instantiate(Item[i], spawnPos, transform.rotation);
        }
    }
}