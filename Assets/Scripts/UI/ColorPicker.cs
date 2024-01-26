using FreeDraw;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    public Color color;
    public Image image;
    
    public DrawingSettings drawingSettings;
    private void Start() {
        drawingSettings = FindObjectOfType<DrawingSettings>();
        image.color = color;
    }
    public void SetColor() {
        drawingSettings.SetMarkerColour(color);
    }
    
}
