﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public bool isGameOver;
    public bool isFalling;
    public static bool showResults = false;
    public static bool isGameWon = false;

    public static int movesMade = 0;
    public Text moves;
    public Text timeGoneBy;
    public API api;
    public static float time = 0;
    public static int lvl = 1;
    int numberOfLevels = 2;

    

	// Use this for initialization
	void Start () {

        isFalling = false;
        isGameOver = false;

        if (!showResults) {
            moves.text = movesMade.ToString() + " moves made";
        }
        else
        {
            ShowResultsText();
            api.ShowResults();
        }
        
        
    }
	
	// Update is called once per frame
	void Update () {

        if (!isGameWon)
        {
            TimeTick();
        }
        else if (!showResults)
        {
            showResults = true;
        }
	}

    public void UpMoveCounter ()
    {
        movesMade++;
        moves.text = movesMade.ToString() + " moves made";
    }

    void TimeTick()
    {
        time += Time.deltaTime;
        timeGoneBy.text = time.ToString("f2");
    }

    public void LoadNextLevel()
    {
        if (!isGameWon)
        {
            SceneManager.LoadScene("Lvl " + lvl, LoadSceneMode.Single);
        }
    }

    public void WaitThenLoad()
    {
        lvl++;
        isGameOver = false;

        if (lvl <= numberOfLevels)
        {
            Invoke("LoadNextLevel", 2.0f);
        }
        else
        {
            isGameWon = true;

            SceneManager.LoadScene("Results", LoadSceneMode.Single);
        }
       
    }

    public void ShowResultsText ()
    {
      
        timeGoneBy.text = "Time Used: "+time.ToString("f2");
        moves.text = "# of Moves Made: " + movesMade.ToString();
    }
}
