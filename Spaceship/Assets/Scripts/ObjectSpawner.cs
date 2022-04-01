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

    //will be executed once at start
    void Start()
    {
        //"Spawn" function will be called repeatedly
        InvokeRepeating("Spawn", spawnDelay, spawnDelay);
    }

    //spawn function
    void Spawn()
    {
        //calculate random position between AsteroidSpawner and RighPosition
        Vector3 spawnPos = new Vector3(Random.Range(transform.position.x, RightPosition.position.x), transform.position.y, 0);
        //calculate random variable i between 0 and array length (number of members)
        int i = Random.Range(0, Item.Length);
        //place prefab at calculated position
        Instantiate(Item[i], spawnPos, transform.rotation);
    }
}