using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    //variable for position, which will be used for calculating random position between two points
    public Transform RightPosition;
    //delay between spawns
    public float spawnDelay;
    //array for prefabs, which should be spawn
    public GameObject[] Item;
    private float width;
    private double widthd;

    //will be executed once at start
    void Start()
    {
        //"Spawn" function will be called repeatedly
        InvokeRepeating("ItemSpawn", spawnDelay, spawnDelay);
        widthd = Screen.width / Screen.dpi;
        width = (float)widthd;
    }

    //spawn function
    void ItemSpawn()
    {
        //calculate random position between AsteroidSpawner and RighPosition
        Vector3 spawnPos = new Vector3(Random.Range(-width, width), transform.position.y, 0);
        //calculate random variable i between 0 and array length (number of members)
        int i = Random.Range(0, Item.Length);
        //place prefab at calculated position
        Instantiate(Item[i], spawnPos, transform.rotation);
    }
}
