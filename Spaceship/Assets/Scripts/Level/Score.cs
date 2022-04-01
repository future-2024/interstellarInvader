using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{

    // Start is called before the first frame update
    //public static Score Instance { get; private set; }
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI maxScoreText;
    public int maxScore;
    public int score;
    public int power;
    int i = 0;
    public bool winBool = false;
    public bool particle = false;
    public GameObject winGame;
    public GameObject win;
    public GameObject ship;
    public PlayerHP hpScript;
    public Text startText;
    public Text countText;
    public Text winText;
    //public static Score Instasnce { get; private set; }
    void Start()
    {
        hpScript = GameObject.Find("SpaceShip").GetComponent<PlayerHP>();
        score = 0;
        i = 0;
        StartCoroutine(loading());
      //  StartCoroutine(toServer());
        //winBool = false;
        if (scoreText)
        {
            scoreText.text = "score: 0";
        }
        if (powerText)
        {
            powerText.text = hpScript.hp.ToString() + "FT";
        }
        //scoreText.GetComponent<TextMeshProUGUI>().text = "Score: 0";
        //Score.Instance.
    }

    // Update is called once per frame
    void Update()
    {   
        if (scoreText)
        {
            scoreText.text = "score: " + score.ToString();
        }
        if (powerText)
        {
            powerText.text = hpScript.hp.ToString() + "FT";
        }
        if (score > maxScore)
        {
            if (maxScoreText)
            {
                maxScoreText.text = maxScore.ToString();
            }
            afterWin();
        }
    }
    void afterWin()
    {
        if (i == 0)
        {
            Instantiate(win, ship.transform.position, Quaternion.identity);
            StartCoroutine(winParticle());
            i = 2;
        }
    }
    /*
    public IEnumerator Sign(string url, userdata user)
    {

        var jsonData = JsonUtility.ToJson(user);
        //Debug.Log(jsonData);
        using (UnityWebRequest www = UnityWebRequest.Post(url, jsonData))

        {

            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                alert.text = www.error;
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    // handle the result
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    //alert.text = result;
                    Debug.Log(result);
                    if (result == "Registered")
                    {
                        alert.text = "Registered Succefully. Please Log in";
                        username.text = "";
                        email.text = "";
                        password.text = "";
                    }
                    else if (result == "exist")
                    {
                        alert.text = "User already exists";
                    }
                    else
                    {
                        alert.text = "Please insert a valid information!";
                    }
                }
                else
                {
                    //handle the problem
                    alert.text = "Error! data couldn't get.";
                    //Debug.Log("Error! data couldn't get.");
                }
            }
        }
    }
    */
    IEnumerator loading()
    {
        yield return new WaitForSeconds(4);
        Destroy(startText);
        Destroy(countText);
        ship.SetActive(true);

    }
    IEnumerator winParticle()
    {
        winBool = true;
        winText.text = "Mission Completed!";
        yield return new WaitForSeconds(5);
        particle = true;
        winText.text = " ";
        winGame.SetActive(true);
        //Time.timeScale = 0;
    }
}
