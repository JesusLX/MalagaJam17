using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : Singleton<MainMenu> {
    public void PlayDrawingScene() {
        SceneManager.LoadScene(1);
    }

    public void PlayBattleScene() {
        SceneManager.LoadScene(2);
    }
}
