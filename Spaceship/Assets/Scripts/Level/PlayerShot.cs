using UnityEngine;
using System.Collections;
//we need the namespace for access on Unity UI
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerShot : MonoBehaviour {

    //variable for laser prefab
    public GameObject[] laser;
    //public LaserShot shotScript;
    //delay between laser shots
    public float delayTime;

    //boolean, if laser can be spawned
    bool canShoot = true;
    public string bulletMode = "default";
    // private int i = 0;
    //will be executed every frame
    void Start ()
    {
        //shotScript = GameObject.Find("scriptContainer").GetComponent<LaserShot>();
        
    }
    void Update () {

        //check if laser can be spawned and right mouse button is pressed
        if (canShoot && Input.GetMouseButton(1)) {
            //disable shooting check for next frame
            canShoot = false;
            //while (i == shotScript.count)
            Debug.Log("before"+bulletMode);
            if (bulletMode == "parallel")
            {
                Instantiate(laser[0], transform.position, transform.rotation);
                Instantiate(laser[0], transform.position + new Vector3(0.4f, 0, 0), transform.rotation);
                Instantiate(laser[0], transform.position - new Vector3(0.4f, 0, 0), transform.rotation);
                //Instantiate(laser, transform.position+0.4, transform.rotation);
            }

            if (bulletMode == "default" || bulletMode == "through")
            {
                Instantiate(laser[0], transform.position, transform.rotation);
                
                //Instantiate(laser, transform.position+0.4, transform.rotation);
            }
            if (bulletMode == "bulletpower" || bulletMode == "speed")
            {
                Instantiate(laser[1], transform.position, transform.rotation);
                
                //Instantiate(laser, transform.position+0.4, transform.rotation);
            }
            //iTween.PunchPosition(gameObject, iTween.Hash("amount", new Vector3(0, -0.1f, 0), "time", 0.2, "delay", 0.005));
            StartCoroutine(NoFire());
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag ==  "parallel")
        {
            bulletMode = other.gameObject.tag;
            Destroy(other.gameObject);
            StartCoroutine(FireAct());
        }
        else if (other.gameObject.tag == "through")
        {
            bulletMode = other.gameObject.tag;
            Destroy(other.gameObject);
            StartCoroutine(FireAct());

        }
        else if (other.gameObject.tag == "bulletpower")
        {
            bulletMode = other.gameObject.tag;
            Destroy(other.gameObject);
            StartCoroutine(FireAct());

        }
        else if (other.gameObject.tag == "speed")
        {
            bulletMode = other.gameObject.tag;
            Destroy(other.gameObject);
            StartCoroutine(FireAct());

        }
    }

    //coroutine function, we can pause it
    IEnumerator NoFire () {

        //pause function and return to it later in "delayTime" seconds
        yield return new WaitForSeconds (delayTime);

        //enable shooting for next check
        canShoot = true;
    }
    IEnumerator FireAct () { 
        yield return new WaitForSeconds(10);
        bulletMode = "default";
    }
    
}