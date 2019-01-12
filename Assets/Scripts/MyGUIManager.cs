using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MyGUIManager : MonoBehaviour {

    [SerializeField]
    TextMeshProUGUI timerGUI;

    [SerializeField]
    string timerGUIString;

    [SerializeField]
    GameObject startObject;

    float timer = 0;
    bool timerOn = false;

	// Use this for initialization
	void Start () {
        timerGUI.text = timerGUIString + " 0";
	}
	
	// Update is called once per frame
	void Update () {
        if (timerOn) {
            timer = timer + Time.deltaTime;
            timerGUI.text = timerGUIString + " " + System.Math.Round(timer, 0);
                }
	}

    public void StartLevelOne()
    {
        SceneManager.LoadScene("LevelOne", LoadSceneMode.Additive);
        startObject.SetActive(false);
        timerOn = true;
    }
}
