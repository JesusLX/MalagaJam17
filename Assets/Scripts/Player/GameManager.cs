using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    public UnityEvent onBattleEnd;
    public UnityEvent onBattleStart;
    public UnityEvent onBattleRestart;
    public void EndBattle(PlayerController winner) {
        onBattleEnd?.Invoke();
    }

    public void StartBattle() {
         onBattleStart?.Invoke();
    }

    public void RestartBattle() {
        onBattleRestart?.Invoke();
    }
}
