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
        Debug.Log("ESCENAAA " + thisScene);
        switch (thisScene) {
            case scene.mm:
                FindObjectOfType<AudioManager>().PlayMusic();
                break;
            case scene.draw:
                FindObjectOfType<AudioManager>().PlayMusic2();
                break;
            case scene.battle:
                FindObjectOfType<AudioManager>().PlayMusic3();
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
