using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearScript : MonoBehaviour {

    public float rotateMultiplier = 1f;
    public bool reverse = false;
    public float angle = 0;
	private Quaternion defaultRotation;
	private RectTransform rect;

    // Use this for initialization
    void Start () {
		rect = GetComponent<RectTransform>();
		defaultRotation = rect.rotation;
	}

	// rotation == delta since last frame
	public void RotateWithDifference(Quaternion newRotation)
	{
		if (!reverse)
		{
			Quaternion finalRotation = Quaternion.LerpUnclamped (rect.rotation, rect.rotation * newRotation, rotateMultiplier);
			rect.rotation = finalRotation;
		} else
		{
			Quaternion finalRotation = Quaternion.LerpUnclamped (rect.rotation, rect.rotation * newRotation, -rotateMultiplier);
			rect.rotation = finalRotation;
		}
	}
}
