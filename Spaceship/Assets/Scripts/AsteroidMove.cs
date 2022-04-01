using UnityEngine;
using System.Collections;
//namespace with different scene controlls
using UnityEngine.SceneManagement;

public class AsteroidMove : MonoBehaviour {

    //variable for flying speed
    public float speed;
    //reference for Rigidbody2D
    Rigidbody2D rb;

    //will be executed once at script start
    void Start () {
        //reference to Rigidbody2D
        rb = GetComponent < Rigidbody2D > ();
        //declare direction vector for moving (this will be along the Y-axe)
        Vector3 move = new Vector3 (0, -1, 0);
        //change velocity (moving speed and direction)
        rb.velocity = move * speed;
    }

    //will be executed if gameobject is not rendered anymore on screen
    void OnBecameInvisible () {
        //delete gameobject from scene
        Destroy (gameObject);
    }

    //will be executed if different Collider2D have touched each other
    void OnCollisionEnter2D (Collision2D something) {

        //check Tag of touched gameobject
        if (something.gameObject.tag == "Player") {

            //delete gameobject from scene
            Destroy (gameObject);

            //load the same scene again (reload)
            SceneManager.LoadScene (SceneManager.GetActiveScene().name);

        }
    }
}