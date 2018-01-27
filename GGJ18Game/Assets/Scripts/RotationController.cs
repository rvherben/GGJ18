using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationController : MonoBehaviour {

	private float baseAngle = 0f;
    private Vector3 euler;

	void OnMouseDown()
	{
		var dir = Camera.main.WorldToScreenPoint(transform.position);
		dir = Input.mousePosition - dir;
		baseAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		baseAngle -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;
	}

	void OnMouseDrag()
	{
		var dir = Camera.main.WorldToScreenPoint(transform.position);
		dir = Input.mousePosition - dir;
		var angle =  Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - baseAngle;
		transform.eulerAngles = Quaternion.AngleAxis(angle, Vector3.forward).eulerAngles;
	}

    public Vector3 getEulerRot(Vector3 Euler)
    {
        return Euler;
    }
}