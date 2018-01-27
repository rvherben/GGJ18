using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSpawner : MonoBehaviour {

    GameObject _blueSpawner;
    GameObject _redSpawner;
    List<GameObject> _activeBalls;
    [SerializeField]
    public Transform _playingField;
    [SerializeField]
    public Color32 red;
    [SerializeField]
    public Color32 blue;
	
	public void Init () {
        _blueSpawner = transform.Find("Blue").gameObject;
        _redSpawner = transform.Find("Red").gameObject;
        _activeBalls = new List<GameObject>();
    }

    public void StartSpawning()
    {
        _SpawnNewBall();
    }

    public void StopSpawning()
    {
        CancelInvoke("_SpawnNewBall");
        foreach(GameObject ball in _activeBalls)
        {
            if (ball != null)
            {
                ResourcesManager.Instance.RemoveResourceInstance(ball);
            }
        }
        ViewManager.Instance.ShowMenu();
    }

    enum BallType
    {
        Red,
        Blue
    }
	
    void _SpawnNewBall()
    {
        int random = Random.Range(0, 2);
        if (random == 1)
        {
            _Spawn(BallType.Blue);
        }
        else
        {
            _Spawn(BallType.Red);
        }
    }

    void _Spawn(BallType type)
    {
        GameObject ball = ResourcesManager.Instance.GetResourceInstance("Game/Ball").gameObject;
        _activeBalls.Add(ball);
        ball.transform.SetParent(_playingField, false);

        if (type == BallType.Red)
        {
            ball.transform.localPosition = _redSpawner.transform.localPosition;
            transform.localScale = Vector3.one;
            ball.gameObject.GetComponent<Image>().color = red;
        }
        else if(type == BallType.Blue)
        {
            ball.transform.localPosition = _blueSpawner.transform.localPosition;
            transform.localScale = Vector3.one;
            ball.gameObject.GetComponent<Image>().color = blue;
        }

        Invoke("_SpawnNewBall", 1);
    }

}
