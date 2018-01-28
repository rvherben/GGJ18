using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : Singleton<AudioManager>
{
    AudioSource _musicSource;
    List<AudioSource> _soundEffectSources;
    int _soundEffectSourceIndex;
    bool _soundOn;

    /* Music clips */
    //[SerializeField]
    //AudioClip _gameMusic;

    /* Sound effect clips */
    [SerializeField]
    AudioClip _buttonTap;
    [SerializeField]
    AudioClip _positive;
    [SerializeField]
    AudioClip _negative;
    [SerializeField]
    AudioClip _gearClick1;
    [SerializeField]
    AudioClip _gearClick2;


    override public void Init()
    {
        _musicSource = Camera.main.transform.Find("MusicSource").GetComponent<AudioSource>();
        _soundEffectSources = new List<AudioSource>();
        _soundEffectSources.AddRange(Camera.main.transform.Find("Audio Source").GetComponents<AudioSource>());

        _soundEffectSourceIndex = -1;
        if (PlayerPrefs.GetInt("sound", 1) == 1)
        {
            _soundOn = true;
        }
        else
        {
            _soundOn = false;
        }
    }

    public void ToggleSoundOn(int preference)
    {
        if (preference==0)
        {
            _soundOn = false;
            _musicSource.Stop();
        }
        else
        {
            _soundOn = true;
        }
    }

    public void PlaySoundEffect(string audioID)
    {
        // Select the next audioSource to use for playing the specified sound effect (NOTE: previous sound effects may be stopped if the number of simultaneous sounds exceeds the amount of sources)
        _soundEffectSourceIndex = (_soundEffectSourceIndex + 1) % _soundEffectSources.Count;
        AudioSource audioSource = _soundEffectSources[_soundEffectSourceIndex];
        switch (audioID)
        {
            case AudioIDs.BUTTON_TAP:
                audioSource.clip = _buttonTap;
                break;
            case AudioIDs.POSITIVE:
                audioSource.clip = _positive;
                break;
            case AudioIDs.NEGATIVE:
                audioSource.clip = _negative;
                break;
            case AudioIDs.GEARCLICK1:
                audioSource.clip = _gearClick1;
                break;
            case AudioIDs.GEARCLICK2:
                audioSource.clip = _gearClick2;
                break;

        }
        if (_soundOn)
        {
            audioSource.Play();
        }
    }

    public void PlayMusic(string audioID)
    {
        switch (audioID)
        {
            /*case AudioIDs.GAME_MUSIC:
                _musicSource.clip = _gameMusic;
                break;*/
        }
        if (_soundOn)
        {
            _musicSource.Play();
        }
    }

    public void StopMusic()
    {
        _musicSource.Stop();
    }

    public void PauseMusic()
    {
        _musicSource.Pause();
    }

    public void UnPauseMusic()
    {
        _musicSource.UnPause();
    }
}

