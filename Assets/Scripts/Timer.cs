using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float maxTime;
    private float myTimer;
    public Image timePanel;

    public float turn;

    private void Start() {
        // timePanel = GetComponent<Image>();
        resetTimer();

        turn = 0;
    }

    private void Update() {
        if(myTimer > 0f){
            changeTimer();
        } else if(turn == 0){
            passTurn();
        }     else {
            MainMenu.instance.PlayDrawingScene();
        }
    }

    private void changeTimer() {
        myTimer -= Time.deltaTime;
        float fraction = myTimer / maxTime;
        Debug.Log(fraction);
        timePanel.fillAmount = fraction;
    }

    private void resetTimer() {
        myTimer = maxTime;
    }

    public void passTurn() {
        if(turn >= 1) {
            
        }   else {
            turn++;
            resetTimer();
        }
        
    }

}
