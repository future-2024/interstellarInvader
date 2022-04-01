using UnityEngine;
using System.Collections;
//we need the namespace for access on Unity UI
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{

    //reference to gameobject HealthBar
    public GameObject HealthBar;
    //reference variable to Image component in HealthBar
    Image img;
    //current HP
    public int hp;
    //maximum HP value, will be used for % count
    float maxHp;

    //will be executed once
    void Start()
    {
        //reference to Image component in PlayerHP
        img = HealthBar.GetComponent<Image>();
        //set maximum HP as current HP
        maxHp = hp;
        //change fill amount between 0 and 1 (here will be 1 or 100%)
        img.fillAmount = hp / maxHp;
    }

    //will be called from the scripts on other gameobjects (like Bullet)
    void MakeDamage(int damage)
    {
        Debug.Log(damage);
        //decrease hp value
        hp = hp - damage;
        //check if hp is zero or negative
        if (hp <= 0)
        {
            //load current scene (reload)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        //change fill amount between 0 and 1
        img.fillAmount = hp / maxHp;
    }
}
