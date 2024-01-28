using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : Singleton<MainMenu> {
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
