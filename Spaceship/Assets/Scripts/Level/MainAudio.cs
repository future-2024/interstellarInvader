using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAudio : MonoBehaviour
{
    AudioSource mainMusic;
    //public AudioClip mainMusic;
    //public AudioClip gameOverMusic;
    private PlayerHP playScript;
    private Score scoreScript;
    //private ModalScript modalScript;
    // Start is called before the first frame update
    void Start()
    {        
        //AudioSource.PlayClipAtPoint(mainMusic, transform.position);
        playScript = GameObject.Find("SpaceShip").GetComponent<PlayerHP>();
        scoreScript = GameObject.Find("ScoreManger").GetComponent<Score>();
        //modalScript = GameObject.Find("optionModal").GetComponent<ModalScript>();
        mainMusic = GetComponent<AudioSource>();
        //mainMusic.Stop();
    }

    // Update is called once per frame
    void Update()
    {
       if(playScript) { 
           if (playScript.gameOver == true)
            {
                mainMusic.Stop();
            }
            else if(scoreScript.particle == true)
            {
                mainMusic.Stop();
            }
        }       
    }
}
