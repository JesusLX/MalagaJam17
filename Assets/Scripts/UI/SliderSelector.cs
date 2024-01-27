using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderSelector : MonoBehaviour
{
    public Slider slider;
    public UnityEvent<float> goTo;

    public void Start() {
        //goTo.Invoke(slider.value);
    }
    public void OnSliderChange() {
        Debug.Log(slider.value,this);
        goTo.Invoke(slider.value);
    }
}
