using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public HPController hpController;
    public bool canAttack;
    public BattleLine battleLine;
    public Transform shotOrigin;
    public PlayerController enemy;
    Animator animator;
    private void Start() {
        animator = GetComponent<Animator>();
        GameManager.instance.onBattleEnd.AddListener(OnBattleEnd);
        GameManager.instance.onBattleStart.AddListener(OnBattleStart);
        GameManager.instance.onBattleRestart.AddListener(OnBattleRestart);
        battleLine.onAttack.AddListener(Attack);
    }
    public void Attack(int multiplier) {
        if (canAttack) {
            animator.SetTrigger("throw");

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
            animator.SetTrigger("die");

            GameManager.instance.EndBattle(gadget.thrower);
        } else {
            animator.SetTrigger("hitted");
        }
    }
    public void OnBattleStart() {
        canAttack = true;
        battleLine.canAttack = canAttack;
    }
    public void OnBattleRestart() {
        canAttack = true;
        battleLine.canAttack = canAttack;
    }
    public void OnBattleEnd() {
        canAttack = false;
        battleLine.canAttack = canAttack;

    }
}
