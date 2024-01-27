using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class UIAnimator : Singleton<UIAnimator>
{
    public RectTransform playerOnePanel, playerTwoPanel;
    public Vector2 playerOnePosition, playerTwoPosition;

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
        Camera.main.gameObject.transform.DOMoveX(playerTwoPosition.x,1f).SetEase(Ease.InBounce);
        AnimatePlayerTurns(playerTwoPanel, () => {
            GameObject player2 = GameObject.FindWithTag("Player2");
            player2.GetComponent<Animator>().SetTrigger("start");
        });
    }
}
