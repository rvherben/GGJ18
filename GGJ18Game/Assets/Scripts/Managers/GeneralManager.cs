using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour {
	void Start () {
        // Initialize other managers
        //AudioManager.Instance.Init();
        ResourcesManager.Instance.Init();
        GameManager.Instance.Init();
	}
}
