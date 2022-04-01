using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;


public class login : MonoBehaviour
{
    public GameObject sign;
    public GameObject log;

    public InputField username;
    public InputField email;
    public InputField password;
    public Text alert;

    //private bool isLoggedIn = false;
    private string prevName;
    private string prevPass;
    public string url;
    public string url2;
    private ArrayList data;

    void Start()
    {
        /*        var user = new userdata()
                {   
                    name = "ssss",
                    email = "kkk@gamil.com",
                    pass = "Aaaaaaa123"
                };
                StartCoroutine(Post(url, user));
         */
        Button loginBut = log.GetComponent<Button>();
        loginBut.onClick.AddListener(LogIn);
        Button signBut = sign.GetComponent<Button>();
        signBut.onClick.AddListener(SignUp);
    }

    // Update is called once per frame
    void SignUp()
    {
        var user = new userdata()
        {
            name = username.text,
            email = email.text,
            pass = password.text
        };
        StartCoroutine(Sign(url, user));
    }
    void LogIn()
    {
        var user = new userdata()
        {
            name = username.text,
            email = email.text,
            pass = password.text
        };
        PlayerPrefs.SetString("name", username.text);
        StartCoroutine(Log(url2, user));
    }
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
                    } else if(result == "exist")
                    {
                        alert.text = "User already exists";
                    } else
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
    public IEnumerator Log(string url2, userdata user)
    {

        var jsonData = JsonUtility.ToJson(user);
        //Debug.Log(jsonData);
        using (UnityWebRequest www = UnityWebRequest.Post(url2, jsonData))

        {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    // handle the result
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    Debug.Log(result);
                    if (result == "Logged In")
                    {
                        alert.text = "Welcome!";
                        PlayerPrefs.Save();
                        //Debug.Log(PlayerPrefs.GetString("name"));
                        //StartCoroutine(Log(url, user));
                        Application.LoadLevel("Loading");
                    }
                }
                else
                {
                    //handle the problem
                    Debug.Log("Error! data couldn't get.");
                }
            }
        }
    }
}
    /*
    public IEnumerator Post(string url, userdata user)
    {
        var jsonData = JsonUtility.ToJson(user);
        Debug.Log(jsonData);
        using (UnityWebRequest www = UnityWebRequest.Post(url, jsonData))
        {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            
        //data = [{"name": username.text }, { "pass": password.text }];
        //WWWForm form = new WWWForm();
        //form.AddField("name", username.text);
        //form.AddField("pass", password.text);
        //Debug.Log(username.text);
        //using (var www = UnityWebRequest.Post(url, form))
        //{
          
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                print(www.error);
            }
            else
            {
                print("Finished Uploading Screenshot");
                if (www.isDone)
                {
                    // handle the result
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    Debug.Log(result);
                    if (result == "true")
                    {
                        Application.LoadLevel("Loading");
                    }
                }
                else
                {
                    //handle the problem
                    Debug.Log("Error! data couldn't get.");
                }
            }
        }
        /*
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        
        yield return www.SendWebRequest();
            
        if (www.result == UnityWebRequest.Result.ConnectionError) 
        {
            Debug.Log(www.error);
        }
        else
        {
            if (www.isDone)
            {
                // handle the result
                var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                Debug.Log(result);
                if(result == "true")
                {
                    Application.LoadLevel("Loading");
                }
            }
            else
            {
                //handle the problem
                Debug.Log("Error! data couldn't get.");
            }
        }
        */



