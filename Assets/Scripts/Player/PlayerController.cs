using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public HPController hpController;
    public bool canAttack;
    public BattleLine battleLine;
    public Transform shotOrigin;
    public PlayerController enemy;
    private void Start() {
        GameManager.instance.onBattleEnd.AddListener(OnBattleEnd);
        GameManager.instance.onBattleStart.AddListener(OnBattleStart);
        battleLine.onAttack.AddListener(Attack);
    }
    public void Attack(int multiplier) {
        if (canAttack) {
            Gadget gadget = GadgetManager.instance.PlayRandom(shotOrigin, shotOrigin.localPosition, shotOrigin.rotation, enemy);
            StartCoroutine(HitWithDelay(2f, gadget));
        }
    }
    IEnumerator HitWithDelay(float delay, Gadget gadget) {
        yield return new WaitForSeconds(delay);
        enemy.GetHit(gadget);
    }
    public void GetHit(Gadget gadget) {
        bool live = hpController.Damage(gadget.damage);
        if (!live) {
            Debug.Log(live, this);
            GameManager.instance.endBattle(gadget.thrower);
        }
    }
    public void OnBattleStart() {
        canAttack = true;
        battleLine.canAttack = canAttack;
    }
    public void OnBattleEnd() {
        canAttack = false;
        battleLine.canAttack = canAttack;

    }
}
