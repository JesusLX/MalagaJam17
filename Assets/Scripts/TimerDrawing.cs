using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerDrawing : MonoBehaviour
{
    public float maxTime;
    private float myTimer;
    public Image timePanel;

    public static float turn;

    private void Start() {
        // timePanel = GetComponent<Image>();

        //ThemeSelector.instance.RunChange();
        Coroutine cor = (ThemeSelector.instance.RunChange());
        StartCoroutine(StartThemeSelector(cor));

        turn = 0;
    }

    IEnumerator StartThemeSelector(Coroutine waitUntilCoroutine) {

        yield return (waitUntilCoroutine);

        UIAnimator.instance.AnimatePlayerOnePanel();

        resetTimer();

        while(myTimer > 0f) {
            if (myTimer > 0f) {
                changeTimer();
            } else if (turn == 0) {
                passTurn();
            } else {
                MainMenu.instance.PlayBattleScene();
            }

            yield return new WaitForEndOfFrame();
        }

    }


    private void changeTimer() {
        myTimer -= Time.deltaTime;
        float fraction = myTimer / maxTime;

        timePanel.fillAmount = fraction;
    }

    private void resetTimer() {
        myTimer = maxTime;
    }

    public void passTurn() {
        if(turn >= 1) {
            MainMenu.instance.PlayBattleScene();
        }   else {
            UIAnimator.instance.AnimatePlayerTwoPanel();
            turn++;
            resetTimer();
        }
        
    }

}
