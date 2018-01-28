﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour {

	public void OnBackButtonClicked()
    {
        ViewManager.Instance.ShowMenu();
        AudioManager.Instance.PlaySoundEffect(AudioIDs.BUTTON_TAP);
    }
}
