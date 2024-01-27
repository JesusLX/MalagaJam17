using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BattleLine : MonoBehaviour {
    public float maxTime;
    public bool canAttack;
    public Image lifePanel;

    public KeyCode pressButton;

    float fraction;
    public float goalValue = 0.92f;

    private void Start() {
        lifePanel = this.gameObject.GetComponent<Image>();
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
            lifePanel.fillAmount = fraction;

            if (myTimer >= maxTime) {
                ascending = false;
            } else if (myTimer <= 0) {
                ascending = true;
            }
            yield return new WaitForEndOfFrame();

        }
    }

    private void Attack() {
        if (fraction >= 0.95f) {
            Debug.Log("ATAQUERRR PERFESTOOOO " + fraction);
        } else if (fraction >= goalValue) {
            Debug.Log("ATAQUERRR con " + fraction);
        } else {
            Debug.Log("Has fallao :(");
            StartCoroutine(FailTime());
        }
    }

    IEnumerator FailTime() {
        Color previousColor = lifePanel.color;
        lifePanel.color = new Color(236, 103, 126);
        lifePanel.transform.DOShakePosition(1f,5,25,120) ;

        canAttack = false;
        yield return new WaitForSeconds(1f);

        lifePanel.color = previousColor;
        StartCoroutine(ChangeTimer());
    }
}
