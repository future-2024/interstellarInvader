using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    //variable for clicked position
    Vector3 clickPos;
    //we will use this vector as velocity for Rigidbody2D (direction and speed)
    Vector3 move;
    //variable for players speed
    public float speed = 1;
    //we will need reference to Players Rigidbody2D
    Rigidbody2D rb;

    //will be executed once at scripts start
    void Start () {
        //reference to Players Rigidbody2D
        rb = GetComponent < Rigidbody2D > ();
        //player should stay on its place at game start (or it will move to clickPos (0,0,0) as default Vector3)
        // clickPos = transform.position;
    }

    //will be executed every frame
    void Update () {
        //check if left mouse button is pressed
        // if (Input.GetMouseButton (0)) {
            //transform mouse screen position to world position
            // clickPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        // }
        //calculate direction vector from ship to clicked point
        // move = clickPos - transform.position;
        move.x = Input.GetAxis ("Horizontal");
        move.y = Input.GetAxis ("Vertical");
    }

    //will be executed at fixed time steps (0.02 default). Use this for Unity physics
    void FixedUpdate () {
        //change velocity to calculated moving vector
        //z will stay zero. Our ship should not move on Z-Axe
        rb.velocity = new Vector2 (move.x, move.y) * speed;
    }
}