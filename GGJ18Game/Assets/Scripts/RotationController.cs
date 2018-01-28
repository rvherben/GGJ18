using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationController : MonoBehaviour {

	private float baseAngle = 0f;
    private Vector3 euler;
	List<Transform> gears;
	Quaternion previousRotation;

	void Start()
	{
		gears = new List<Transform> ();
		gears.Add (GameObject.Find ("PlayingField").transform.GetChild (0));
		gears.Add (GameObject.Find ("PlayingField").transform.GetChild (1));
		gears.Add (GameObject.Find ("PlayingField").transform.GetChild (2));
		gears.Add (GameObject.Find ("PlayingField").transform.GetChild (3));
        gears.Add(GameObject.Find("Background").transform.GetChild(0));
        gears.Add(GameObject.Find("Background").transform.GetChild(1));
        gears.Add(GameObject.Find("Background").transform.GetChild(2));
        gears.Add(GameObject.Find("Background").transform.GetChild(3));
        gears.Add(GameObject.Find("Background").transform.GetChild(4));
        previousRotation = transform.rotation;
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
		Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		Quaternion rotationDifference = rotation * Quaternion.Inverse (previousRotation);

		foreach (Transform gear in gears)
		{
			gear.GetComponent<GearScript> ().RotateWithDifference (rotationDifference);
		}
		previousRotation = rotation;
	}
}