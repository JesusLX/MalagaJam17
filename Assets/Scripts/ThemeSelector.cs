using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThemeSelector : Singleton<ThemeSelector>
{
    public string[] myThemeList;
    public TextMeshProUGUI mText;
    public float themeSelectorTime = 5;

    // Start is called before the first frame update
    void Start()
    {

        mText = this.gameObject.GetComponent<TextMeshProUGUI>();
        mText.text = "prueba";

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

        float waitTime = 0.01f;

        while(time > 0) {
            waitTime += 0.001f;
            time -= waitTime;
           

            ReturnTheme();
            yield return new WaitForSeconds(waitTime);
        }

    }


}
