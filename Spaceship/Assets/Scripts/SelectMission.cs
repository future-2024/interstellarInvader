using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectMission : MonoBehaviour
{
    // Start is called before the first frame update
    public Button Hydro;
    public Button Centaurus;
    public Button Andromedas;
    public Button Dorado;
    void Start()
    {
        Button hydroBut = Hydro.GetComponent<Button>();
        hydroBut.onClick.AddListener(HydroEvent);
        Button centBut = Centaurus.GetComponent<Button>();
        centBut.onClick.AddListener(CentEvent);
        Button androBut = Andromedas.GetComponent<Button>();
        androBut.onClick.AddListener(AndroEvent);
        Button doraBut = Dorado.GetComponent<Button>();
        doraBut.onClick.AddListener(DoradoEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void HydroEvent()
    {
        PlayerPrefs.SetString("land", "hydro");
        Application.LoadLevel("HydraList");
    }
    void CentEvent()
    {
        PlayerPrefs.SetString("land", "cent");
        Application.LoadLevel("CentList");
    }
    void AndroEvent()
    {
        PlayerPrefs.SetString("land", "andro");
        Application.LoadLevel("AndroList");
    }
    void DoradoEvent()
    {
        PlayerPrefs.SetString("land", "dora");
        Application.LoadLevel("DoradoList");
    }
}
