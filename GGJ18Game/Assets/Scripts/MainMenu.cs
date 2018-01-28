using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public void HandleStartButton()
    {
        ViewManager.Instance.ShowGame();
        AudioManager.Instance.PlaySoundEffect(AudioIDs.BUTTON_TAP);
    }

    public void HandleSettingsButton()
    {
        ViewManager.Instance.ShowSettings();
        AudioManager.Instance.PlaySoundEffect(AudioIDs.BUTTON_TAP);
    }

    public void HandleQuitButton()
    {
        AudioManager.Instance.PlaySoundEffect(AudioIDs.BUTTON_TAP);
        Application.Quit();
    }
}
