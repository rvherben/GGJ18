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
    //[SerializeField]
    //AudioClip _timerTick3;


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
            /*case AudioIDs.TIMER_TICK_1:
                audioSource.clip = _timerTick1;
                break;*/
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

