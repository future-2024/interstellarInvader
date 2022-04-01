using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour
{

    //variable for Bullet prefab
    public GameObject bullet;
    //delay between shots
    public float fireDelay;
    //variable for Player gameobject
    GameObject player;
    //boolean for check if Enemy can shoot
    bool canShoot = true;

    //will be executed once
    void Start()
    {
        //search for gameobject with tag "Player" and reference it to player
        player = GameObject.FindWithTag("Player");
    }

    //will be executed every frame
    void Update()
    {
        //check if Player is in the scene and Enemy can shoot
        if (canShoot && player != null)
        {
            //Enemy cannot shoot in next check
            canShoot = false;
            //place Bullet prefab in the scene at Enemys position (default rotation)
            Instantiate(bullet, transform.position, Quaternion.identity);
            //start firePause function as coroutine, which can be paused
            StartCoroutine(firePause());
        }
    }

    //coroutine function
    IEnumerator firePause()
    {
        //pause funktion for fireDelay seconds
        yield return new WaitForSeconds(fireDelay);
        //Enemy can shoot in next check
        canShoot = true;
    }
}