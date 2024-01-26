using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleColor : MonoBehaviour
{
    Image image;
    void Start()
    {
        image = GetComponent<Image>();    
    }

    public void SetColor(Color color) {
        image.color = color;
    }

}
