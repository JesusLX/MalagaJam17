using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    public UnityEvent onBattleEnd;
    public UnityEvent onBattleStart;
    public UnityEvent onBattleRestart;

    public GameObject finishPanel;

    private void Start() {
        StartBattle();
    }

    public void EndBattle(PlayerController winner) {
        finishPanel.SetActive(true);
        onBattleEnd?.Invoke();
    }

    public void StartBattle() {
         onBattleStart?.Invoke();
    }

    public void RestartBattle() {
        finishPanel.SetActive(false);
        onBattleRestart?.Invoke();
    }
}
