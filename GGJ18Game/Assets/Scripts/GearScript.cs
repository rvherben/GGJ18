using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearScript : MonoBehaviour {

    public float rotateMultiplier = 1f;
    public bool reverse = false;
    public float angle = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.eulerAngles *= angle;

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
