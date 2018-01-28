using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour {

    [SerializeField]
    Sprite soundOnSprite;
    [SerializeField]
    Sprite soundOffSprite;
    [SerializeField]
    Image soundButtonImage;

    public void Set()
    {
        if (Settings.audioEnabled)
        {
            soundButtonImage.sprite = soundOnSprite;
        }
        else
        {
            soundButtonImage.sprite = soundOffSprite;
        }
    }

    public void OnClick()
    {
        AudioManager.Instance.PlaySoundEffect(AudioIDs.BUTTON_TAP);
        Settings.audioEnabled = !Settings.audioEnabled;
        if (Settings.audioEnabled)
        {
            PlayerPrefs.SetInt("sound", 1);
            AudioManager.Instance.ToggleSoundOn(1);
            soundButtonImage.sprite = soundOnSprite;
        }
        else
        {
            PlayerPrefs.SetInt("sound", 0);
            AudioManager.Instance.ToggleSoundOn(0);
            soundButtonImage.sprite = soundOffSprite;
        }
    }
}
