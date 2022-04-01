using UnityEngine;
using System.Collections;
//namespace with different scene controlls
using UnityEngine.SceneManagement;

public class ItemsMove : MonoBehaviour
{

    //variable for flying itemSpeed
    public float itemSpeed;
    private PlayerHP PlayerHP;
    //reference for Rigidbody2D
    Rigidbody2D rigidBody;

    //will be executed once at PlayerHP start
    void Start()
    {
        //reference to Rigidbody2D
        rigidBody = GetComponent<Rigidbody2D>();

        PlayerHP = GameObject.Find("SpaceShip").GetComponent<PlayerHP>();
        InvokeRepeating("ItemMove", 0, 2);
        //declare direction vector for moving (this will be along the Y-axe)
    }

    //will be executed if gameobject is not rendered anymore on screen
    void OnBecameInvisible()
    {
        //delete gameobject from scene
        Destroy(gameObject);
    }

    //will be executed if different Collider2D have touched each other
    void OnCollisionEnter2D(Collision2D collid)
    {

        //check Tag of touched gameobject
        if (collid.gameObject.tag == "Player")
        {
            //Time.timeScale = 0;
            //PlayerHP.gameOver = true;
            //PlayerHP.gameoverObject.SetActive(true);
            //delete gameobject from scene
            Destroy (gameObject);
            //load the same scene again (reload)
            //SceneManager.LoadScene (SceneManager.GetActiveScene().name);
        }
    }
    private void ItemMove()
    {
        if (PlayerHP.gameOver == false)
        {
            Vector3 ItemMove = new Vector3(Random.Range(-1, 1), Random.Range(0, -5), 0);
            //change velocity (moving itemSpeed and direction)
            rigidBody.velocity = ItemMove * itemSpeed;
        }
    }
}