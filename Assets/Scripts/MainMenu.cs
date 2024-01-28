using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : Singleton<MainMenu> {
    public enum scene {
        mm,draw,battle
    }
    public scene thisScene;
    private void Start() {
        switch (thisScene) {
            case scene.mm:
                AudioManager.instance.PlayMusic();
                break;
            case scene.draw:
                AudioManager.instance.PlayMusic2();
                break;
            case scene.battle:
                AudioManager.instance.PlayMusic3();
                break;
        }
    }
    public void PlayMMScene() {
        SceneManager.LoadScene(0);
    }
    public void PlayDrawingScene() {
        SceneManager.LoadScene(1);
    }
    public void PlayBattleScene() {
        SceneManager.LoadScene(2);
    }
}
