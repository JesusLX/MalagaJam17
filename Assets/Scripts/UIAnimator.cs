using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using TMPro;

public class UIAnimator : Singleton<UIAnimator> {
    public RectTransform playerOnePanel, playerTwoPanel;
    public RectTransform countdownText;
    public Vector2 playerOnePosition, playerTwoPosition;

    private void Start() {
        if (countdownText != null) {
            CountdownBattle();
        }
    }

    private void AnimatePlayerTurns(RectTransform playerPanel, Action onComplete) {
        playerPanel.DOAnchorPos(Vector2.zero, 3f).SetEase(Ease.OutElastic).OnComplete(() => {
            playerPanel.DOAnchorPos(new Vector2(10000, 0), 1.25f);
            onComplete();
        });

    }

    public void AnimatePlayerOnePanel() {
        AnimatePlayerTurns(playerOnePanel, () => {
            GameObject player1 = GameObject.FindWithTag("Player1");
            player1.GetComponent<Animator>().SetTrigger("start");
        });
    }

    public void AnimatePlayerTwoPanel() {
        Camera.main.gameObject.transform.DOMoveX(playerTwoPosition.x, 1f).SetEase(Ease.InBounce);
        AnimatePlayerTurns(playerTwoPanel, () => {
            GameObject player2 = GameObject.FindWithTag("Player2");
            player2.GetComponent<Animator>().SetTrigger("start");
        });
    }

    public void CountdownBattle() {
        countdownText.GetComponent<TextMeshProUGUI>().text = "3";

        Sequence mySeq = DOTween.Sequence();
        mySeq.Append(countdownText.DOScale(3, 1f).SetEase(Ease.OutElastic).OnComplete(() => {
            countdownText.GetComponent<TextMeshProUGUI>().text = "2";
            countdownText.transform.localScale = Vector3.one;
        }));
        //mySeq.Append(countdownText.DOScale(1, 1f).SetEase(Ease.OutElastic));
        mySeq.Append(countdownText.DOScale(3, 1f).SetEase(Ease.OutElastic).OnComplete(() => {
            countdownText.GetComponent<TextMeshProUGUI>().text = "1";
            countdownText.transform.localScale = Vector3.one;
        }));
        //mySeq.Append(countdownText.DOScale(1, 1f).SetEase(Ease.OutElastic));
        mySeq.Append(countdownText.DOScale(3, 1f).SetEase(Ease.OutElastic).OnComplete(() => {
            countdownText.GetComponent<TextMeshProUGUI>().text = "Go!";
            countdownText.transform.localScale = Vector3.one;
        }));
        mySeq.Append(countdownText.DOScale(3, 1f).SetEase(Ease.OutElastic).OnComplete(() => {
            countdownText.GetComponent<TextMeshProUGUI>().text = "Go!";
            //countdownText.transform.localScale = Vector3.one;
            countdownText.gameObject.SetActive(false);
        }));

        mySeq.Play();
    }

}
