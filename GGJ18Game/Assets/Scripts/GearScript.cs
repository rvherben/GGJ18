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

	public void RotateWithEuler(Vector3 euler)
	{
		if (!reverse)
		{
			transform.eulerAngles = euler*rotateMultiplier;
		} else
		{
			transform.eulerAngles = euler*-rotateMultiplier;
		}
	}
}
