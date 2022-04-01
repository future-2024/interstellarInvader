using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    //variable for clicked position
    Vector3 clickPos;
    //we will use this vector as velocity for Rigidbody2D (direction and speed)
    Vector3 move;
    //variable for players speed
    private float speed = 10;

    private float width;
    private double widthd;
    private PlayerHP script;

    private float height;
    private float heightd;
    
    Collider2D m_ObjectCollider;

    //we will need reference to Players Rigidbody2D
    Rigidbody2D rb;

    //will be executed once at scripts start
    void Start() {
        script = GameObject.Find("SpaceShip").GetComponent<PlayerHP>();
        rb = GetComponent<Rigidbody2D>();
        m_ObjectCollider = GetComponent<Collider2D>();
        
        //player should stay on its place at game start (or it will move to clickPos (0,0,0) as default Vector3)
        // clickPos = transform.position;
    }

    //will be executed every frame
    void OnCollisionEnter2D(Collision2D collid)
    {

        //check Tag of touched gameobject
        if (collid.gameObject.tag == "speedUp")
        {
            speed = speed + 5;
            StartCoroutine(speedup());
        }
        if (collid.gameObject.tag == "fly")
        {
            m_ObjectCollider.isTrigger = true;
            StartCoroutine(fly());
        }

    }
    IEnumerator speedup()
    {
        yield return new WaitForSeconds(10);
        speed = 10;
    }
    IEnumerator fly()
    {
        yield return new WaitForSeconds(10);
        m_ObjectCollider.isTrigger = false;
        Debug.Log("here");
    }
    
    void Update () {
        //check if left mouse button is pressed
        // if (Input.GetMouseButton (0)) {
        //transform mouse screen position to world position
        // clickPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        // }
        //calculate direction vector from ship to clicked point
        // move = clickPos - transform.position;
        // if (script.gameOver == false)
        // {
    
            widthd = Screen.width / Screen.dpi;
            width = (float)widthd;

            heightd = Screen.height / Screen.dpi;
            height = (float)heightd;

            move.x = Input.GetAxis("Horizontal");
            move.y = Input.GetAxis("Vertical");
    

       // }
    }
    void FixedUpdate () {
        //Debug.Log("Screen Width : " + Screen.width + "xPos" + transform.position.x);
        //change velocity to calculated moving vector
        //z will stay zero. Our ship should not move on Z-Axe
        //if(transform.position.x > -5 && transform.position.x < 10)
        rb.velocity = new Vector2 (move.x, move.y) * speed;
        if (move.x != 0)
        {
            StartCoroutine(rotatex());
        }
        if (transform.position.x >width)
        {
            transform.position = new Vector2(width, transform.position.y);
            
        }
        if ( transform.position.x < -width)
        {
            transform.position = new Vector2(-width, transform.position.y);
        }
        if(transform.position.y > height)
        {
            transform.position = new Vector2(transform.position.x, height);
            
        }
        if ( transform.position.y < -height)
        {
            transform.position = new Vector2(transform.position.x, -height);
        }
    }
    IEnumerator rotatex()
    {
        transform.Rotate(0, 1.5f, 0, Space.Self);
        yield return new WaitForSeconds(0.5f);
        
        transform.Rotate(0, -1.5f, 0, Space.Self);
    }
}