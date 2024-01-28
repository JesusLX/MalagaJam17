using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerDrawing : MonoBehaviour {
    public float maxTime;
    private float myTimer;
    public Slider timePanel;
    public List<GameObject> activateInDrawTurnObjects;
    Coroutine timerCoroutine;

    public static Turns turn = Turns.themeSelector;
    public enum Turns {
        themeSelector, drawPlayer1 ,drawPlayer2, battle, endBattle
    }

    private void Start() {
        // timePanel = GetComponent<Image>();

        //ThemeSelector.instance.RunChange();
        resetTimer();
        Coroutine cor = (ThemeSelector.instance.RunChange());
        timerCoroutine = StartCoroutine(StartThemeSelector(cor));
        turn = Turns.themeSelector;
    }

    IEnumerator StartThemeSelector(Coroutine waitUntilCoroutine) {

        yield return (waitUntilCoroutine);
        if (waitUntilCoroutine != null)
            passTurn();

        resetTimer();

        while (myTimer > 0f) {
            if (myTimer > 0f) {
                changeTimer();
                Debug.Log("Timer " + myTimer);
            }

            yield return new WaitForEndOfFrame();
        }
        passTurn();

    }


    private void changeTimer() {
        myTimer -= Time.deltaTime;
        float fraction = 0;
        if (myTimer > 0f) {
            fraction = myTimer / maxTime;
        }

        timePanel.value = fraction;
    }

    private void resetTimer() {
        myTimer = maxTime;
  
    }

    [ContextMenu("PassTurn")]
    public void passTurn() {
        Debug.Log(turn);
        turn++;
        Debug.Log(turn);
        switch (turn) {
            case Turns.themeSelector:
                break;
            case Turns.drawPlayer1:
                activateInDrawTurnObjects.ForEach(o => o.SetActive(true));
                resetTimer();
                UIAnimator.instance.AnimatePlayerOnePanel();
                break;
            
            case Turns.drawPlayer2:
                resetTimer();
                if (timerCoroutine != null)
                    StopCoroutine(timerCoroutine);
                timerCoroutine = StartCoroutine(StartThemeSelector(null));

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
