using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MyGUIManager : MonoBehaviour {

    [SerializeField]
    TextMeshProUGUI timerGUI;
    [SerializeField]
    TextMeshProUGUI finalTimeGUI;

    [SerializeField]
    string timerGUIString;

    [SerializeField]
    GameObject startObject;
    [SerializeField]
    GameObject gameOverObject;

    float timer = 0;
    bool timerOn = false;

    Camera myCamera;

    private void Awake()
    {
        gameOverObject.SetActive(false);
        myCamera = FindObjectOfType<Camera>();
    }

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
        gameOverObject.SetActive(false);
        timer = 0;
        timerOn = true;
    }

    public void GameOver()
    {
        timerOn = false;
        double finalTime = System.Math.Round(timer, 0);
        SceneManager.UnloadSceneAsync("LevelOne");
        myCamera.gameObject.SetActive(true);
        gameOverObject.SetActive(true);
        finalTimeGUI.text = finalTime + " seconds";
    }
}
