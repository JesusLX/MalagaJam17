using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThemeSelector : Singleton<ThemeSelector>
{
    public string[] myThemeList;
    public TextMeshProUGUI mText;
    public float themeSelectorTime = 5;
    public List<ParticleSystem> themeSelectedParticles;

    public RectTransform panelThemeSelector;
    // Start is called before the first frame update
    void Start()
    {

        mText = this.gameObject.GetComponent<TextMeshProUGUI>();
        //mText.text = "prueba";

        // RunChange();
    }


    [ContextMenu("Change theme once")]
    private void ReturnTheme() {
        int max = myThemeList.Length;
        Debug.Log(myThemeList[Random.Range(0, max)]);

        mText.text = myThemeList[Random.Range(0, max)];
    }

    [ContextMenu("Do Change in few seconds")]
    public Coroutine RunChange() {
        return StartCoroutine(ChangeWords(themeSelectorTime));
    }

    IEnumerator ChangeWords(float time) {
        float moveTime = 1f;
        float moveBackTime = 0.5f;
        Vector3 initPos = mText.rectTransform.localPosition;
        Vector3 initScale = mText.rectTransform.localScale;
        panelThemeSelector.DOAnchorPos(Vector2.zero, 3f).SetEase(Ease.OutElastic);
        mText.rectTransform.DOLocalMove(Vector3.zero, moveTime);
        mText.rectTransform.DOScale(Vector3.one * 5, moveTime);
        float waitTime = 0.01f;
        yield return new WaitForSeconds(moveTime);

        while (time > 0) {
            waitTime += 0.001f;
            time -= waitTime;
           

            ReturnTheme();
            yield return new WaitForSeconds(waitTime);
        }
        themeSelectedParticles.ForEach(particle => { particle.Play(); });
        yield return new WaitForSeconds(2f);

        //panelThemeSelector.DOAnchorPos(Vector2.zero, 3f).SetEase(Ease.OutElastic).OnComplete(() => {
        //    panelThemeSelector.DOAnchorPos(new Vector2(10000, 0), 1.25f);
        //});

        panelThemeSelector.DOAnchorPos(new Vector2(10000, 0), 1.25f);
        mText.rectTransform.DOLocalMove(initPos, moveBackTime);
        mText.rectTransform.DOScale(initScale, moveBackTime);
        yield return new WaitForSeconds(moveBackTime);

    }


}
