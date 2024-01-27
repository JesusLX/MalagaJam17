using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleLine : MonoBehaviour
{
    public float maxTime;
    public bool canAttack;
    public Image lifePanel;

    float fraction;
    public float goalValue = 0.92f;

    private void Start() {
        lifePanel = this.gameObject.GetComponent<Image>();
        StartCoroutine(ChangeTimer());
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Attack();
        }
    }

    IEnumerator ChangeTimer() {
        float myTimer = 0;
        bool ascending = true;

        while (!canAttack) {
            if (ascending) {
                myTimer += Time.deltaTime;
            }     else {
                myTimer -= Time.deltaTime;
            }

            fraction = myTimer / maxTime;
            lifePanel.fillAmount = fraction;

            if (myTimer >= maxTime) {
                ascending = false;
            } else if(myTimer <= 0){
                ascending = true;
            }
            yield return new WaitForEndOfFrame();

        } 
    }

    private void Attack() {
                   if(fraction >= goalValue) {
            Debug.Log("ATAQUERRR con " + fraction);
        }     else {
            Debug.Log("Has fallao :(");
            StartCoroutine(FailTime());
        }
    }

    IEnumerator FailTime() {
        lifePanel.fillAmount = 0;
        canAttack = false;
        yield return new WaitForSeconds(2f);
        canAttack = true;
    }


}
