using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    public UnityEvent onBattleEnd;
    public UnityEvent onBattleStart;
    public void endBattle(PlayerController winner) {
        onBattleEnd?.Invoke();
    }
}
