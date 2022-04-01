using UnityEngine;
using System.Collections;

public class PlayerShot : MonoBehaviour {

    //variable for laser prefab
    public GameObject laser;

    //delay between laser shots
    public float delayTime;

    //boolean, if laser can be spawned
    bool canShoot = true;

    //will be executed every frame
    void Update () {

        //check if laser can be spawned and right mouse button is pressed
        if (canShoot && Input.GetMouseButton(1)) {
            //disable shooting check for next frame
            canShoot = false;

            //place laser prefab in the scene at ships position (rotate as ship)
            Instantiate (laser, transform.position, transform.rotation);

            //start function (which will enable shooting) as coroutine
            StartCoroutine (NoFire());
        }
    }

//coroutine function, we can pause it
IEnumerator NoFire () {

    //pause function and return to it later in "delayTime" seconds
    yield return new WaitForSeconds (delayTime);

    //enable shooting for next check
    canShoot = true;
}
}