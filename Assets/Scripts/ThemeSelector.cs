using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThemeSelector : MonoBehaviour
{
    public string[] myThemeList;
    public TextMeshProUGUI mText;


    // Start is called before the first frame update
    void Start()
    {

                mText = this.gameObject.GetComponent<TextMeshProUGUI>();
        mText.text = "prueba";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Do Something")]
    private void ReturnTheme() {
        int max = myThemeList.Length;
        Debug.Log(myThemeList[Random.Range(0, max)]);

        mText.text = myThemeList[Random.Range(0, max)];
    }
}
