using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class BattleLine : MonoBehaviour {
    public float maxTime;
    public bool canAttack;
    public Slider lifePanel;
    public UnityEvent<int> onAttack;

    public KeyCode pressButton;

    float fraction;
    public float maxValue = 10f;

    private void Start() {
        lifePanel = this.gameObject.GetComponentInChildren<Slider>();
        lifePanel.maxValue = maxValue;
        lifePanel.value = 0;
        StartCoroutine(ChangeTimer());
    }
    private void Update() {
        if (Input.GetKeyDown(pressButton)) {
            Attack();
        }
    }

    IEnumerator ChangeTimer() {
        float myTimer = 0;
        canAttack = true;
        bool ascending = true;

        while (canAttack) {
            if (ascending) {
                myTimer += Time.deltaTime;
            } else {
                myTimer -= Time.deltaTime;
            }

            fraction = myTimer / maxTime;
            lifePanel.value = fraction;

            if (myTimer >= maxTime) {
                ascending = false;
            } else if (myTimer <= 0) {
                ascending = true;
            }
            yield return new WaitForEndOfFrame();

        }
    }

    private void Attack() {
        float exact = maxValue/2;
        float criticMargen = .03f;
        float errorMargen = .20f;
        if (fraction >= exact-criticMargen && fraction <= exact + criticMargen) {
            onAttack.Invoke(2);
            Debug.Log("ATAQUERRR PERFESTOOOO " + fraction);
        } else if (fraction >= exact - errorMargen && fraction <= exact + errorMargen) {
            onAttack.Invoke(1);
            Debug.Log("ATAQUERRR con " + fraction);
        } else {
            Debug.Log("Has fallao :(");
            StartCoroutine(FailTime());
        }
    }

    IEnumerator FailTime() {
        //Color previousColor = lifePanel.image.;
        //lifePanel.color = new Color(236, 103, 126);
        lifePanel.transform.DOShakePosition(1f,5,25,120) ;

        canAttack = false;
        yield return new WaitForSeconds(1f);

        //lifePanel.color = previousColor;
        StartCoroutine(ChangeTimer());
    }

    public void StartCanAttack() {
        StartCoroutine(ChangeTimer());
    }
}
