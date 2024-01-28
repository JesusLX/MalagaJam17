using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour{
    public Slider slider;
    public float maxHP;
    public float HP;

    private void Start() {
        slider = GetComponent<Slider>();

    }
    public void Init() {
        slider.value = maxHP;
        slider.maxValue = maxHP;
        slider.enabled = false;
        HP = maxHP;
    }
    public bool Damage(float damage) {
        bool live = true;
        if (slider != null) {
            HP = HP - damage;
            if ( (HP <= 0)) {
                HP = 0;
                live = false;
            }
            slider.value = HP;
        }
        return live;
    }
}