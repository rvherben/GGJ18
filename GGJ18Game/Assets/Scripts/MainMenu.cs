using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public void HandleStartButton()
    {
        ViewManager.Instance.ShowGame();
    }

    public void HandleSettingsButton()
    {
        ViewManager.Instance.ShowSettings();
    }

    public void HandleQuitButton()
    {
        Application.Quit();
    }
}
