using UnityEngine;
using System.Collections;

public class HpController : MonoBehaviour
{

    //variable for health points
    public int hp;
    //variable for sound clip
    public AudioClip ExplosionsSound;
    //variable for explosion prefab
    public GameObject Explosion;

    //funkton for damage calculation (we will get damage from other functions)
    void MakeDamage(int damage)
    {
        //decrease hp variable
        hp = hp - damage;
        //check if hp is negative or zero
        if (hp <= 0)
        {
            //play sound (gameobject will be created at the position, which will play the sound and then destroy itself)
            AudioSource.PlayClipAtPoint(ExplosionsSound, transform.position);
            //place explosion on gameobject position
            Instantiate(Explosion, transform.position, Quaternion.identity);
            //delete gameobject
            Destroy(gameObject);
        }
    }
}