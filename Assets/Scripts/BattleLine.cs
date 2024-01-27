using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleLine : MonoBehaviour
{
    public float maxTime;
    public bool canAttack;
    public Image lifePanel;

    private void Start() {
        lifePanel = this.gameObject.GetComponent<Image>();
        StartCoroutine(ChangeTimer());
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

            float fraction = myTimer / maxTime;
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

    }
}
