using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationController : MonoBehaviour {

	private float baseAngle = 0f;
    private Vector3 euler;
	List<Transform> gears;

	void Start()
	{
		gears = new List<Transform> ();
		gears.Add (GameObject.Find ("PlayingField").transform.GetChild (0));
		gears.Add (GameObject.Find ("PlayingField").transform.GetChild (1));
		gears.Add (GameObject.Find ("PlayingField").transform.GetChild (2));
	}

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
        euler = Quaternion.AngleAxis(angle, Vector3.forward).eulerAngles;
        transform.eulerAngles = euler;

		foreach (Transform gear in gears)
		{
			gear.GetComponent<GearScript> ().RotateWithEuler (euler);
		}
	}
}