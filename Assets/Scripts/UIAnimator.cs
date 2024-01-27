using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class UIAnimator : Singleton<UIAnimator>
{
    public RectTransform playerOnePanel, playerTwoPanel;

    private void AnimatePlayerTurns(RectTransform playerPanel) {
        playerPanel.DOAnchorPos(Vector2.zero, 3f).SetEase(Ease.OutElastic).OnComplete(() => {
            playerPanel.DOAnchorPos(new Vector2(10000, 0), 1.25f);
        });

    }

    public void AnimatePlayerOnePanel() {
        AnimatePlayerTurns(playerOnePanel);
    }

    public void AnimatePlayerTwoPanel() {
        AnimatePlayerTurns(playerTwoPanel);
    }
}
