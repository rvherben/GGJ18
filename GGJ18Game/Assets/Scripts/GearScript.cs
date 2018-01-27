using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearScript : MonoBehaviour {

    public float rotateMultiplier = 1f;
    public bool reverse = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!reverse)
        {
            RotationManager.Instance.Rotate(rotateMultiplier);
        }

        if (reverse)
        {
            RotationManager.Instance.CounterRotate(rotateMultiplier);
        }

    }
}
