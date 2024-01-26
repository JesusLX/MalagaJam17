using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class UIAnimator : MonoBehaviour
{
    public RectTransform playerOnePanel, playerTwoPanel;

    private void Start() {
        playerOnePanel.DOAnchorPos(Vector2.zero, 2f).OnComplete(() => {
            playerOnePanel.DOAnchorPos(new Vector2(10000, 0), 0.25f);
        });

    }
}
