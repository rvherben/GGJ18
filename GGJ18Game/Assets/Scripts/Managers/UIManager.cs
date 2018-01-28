using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager> {

    [SerializeField]
    public Text _scoreText;

    int _score = 0;

    public void UpdateScore(int scoreGained)
    {
        _score += scoreGained;
        _scoreText.text = _score.ToString();
    }

    public void ResetUI()
    {
        _score = 0;
        _scoreText.text = _score.ToString();
    }
}
