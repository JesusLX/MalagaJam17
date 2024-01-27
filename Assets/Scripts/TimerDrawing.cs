using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerDrawing : MonoBehaviour {
    public float maxTime;
    private float myTimer;
    public Image timePanel;

    public static Turns turn = Turns.themeSelector;
    public enum Turns {
        themeSelector, drawPlayer1, drawPlayer2, battle, endBattle
    }

    private void Start() {
        // timePanel = GetComponent<Image>();

        //ThemeSelector.instance.RunChange();
        Coroutine cor = (ThemeSelector.instance.RunChange());
        StartCoroutine(StartThemeSelector(cor));

        turn = Turns.themeSelector;
    }

    IEnumerator StartThemeSelector(Coroutine waitUntilCoroutine) {

        yield return (waitUntilCoroutine);
        passTurn();

        resetTimer();

        while (myTimer > 0f) {
            if (myTimer > 0f) {
                changeTimer();
            } else {
                passTurn();
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

    [ContextMenu("PassTurn")]
    public void passTurn() {
        turn++;
        switch (turn) {
            case Turns.themeSelector:
                break;
            case Turns.drawPlayer1:
                resetTimer();
                UIAnimator.instance.AnimatePlayerOnePanel();
                break;
            case Turns.drawPlayer2:
                resetTimer();
                UIAnimator.instance.AnimatePlayerTwoPanel();
                break;
            case Turns.battle:
                MainMenu.instance.PlayBattleScene();
                break;
            case Turns.endBattle:
                break;
        }


    }

}
