using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearScript : MonoBehaviour {

    public float rotateMultiplier = 1f;
    public bool reverse = false;
    public float angle = 0;
	private Vector3 defaultEuler;

    // Use this for initialization
    void Start () {
		defaultEuler = transform.eulerAngles;
	}

	public void RotateWithEuler(Vector3 euler)
	{
		if (!reverse)
		{
			transform.eulerAngles = defaultEuler + (euler * rotateMultiplier);
		} else
		{
			transform.eulerAngles = defaultEuler + (euler * -rotateMultiplier);
		}
	}
}
