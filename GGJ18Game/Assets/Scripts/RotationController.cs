using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationController : MonoBehaviour {

	private bool hintDeleted = false;
	private float baseAngle = 0f;
    private Vector3 euler;
	List<Transform> gears;
	Quaternion previousRotation;
    const float CLICK_COOLDOWN = 10;
    float cooldown;
    bool clickswitch = false;
    float rotationCount = 0;
    const float ANGLE_CLICK_THRESHOLD = 0.3f;
	const float ROTATION_CAP = 0.3f;

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
		if (!hintDeleted)
		{
			GameObject.Find ("RotationHint").SetActive (false);
			hintDeleted = true;
		}
		var dir = Camera.main.WorldToScreenPoint(transform.position);
		dir = Input.mousePosition - dir;
		var angle =  Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - baseAngle;
		Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		Quaternion rotationDifference = rotation * Quaternion.Inverse (previousRotation);
		if (rotationDifference.z > ROTATION_CAP)
			rotationDifference.z = ROTATION_CAP;
		else if (rotationDifference.z < -ROTATION_CAP)
			rotationDifference.z = -ROTATION_CAP;
		Debug.Log ("rotationdifference = " + rotationDifference.z);
        rotationCount += rotationDifference.z;
        if (rotationCount > ANGLE_CLICK_THRESHOLD || rotationCount < -ANGLE_CLICK_THRESHOLD)
        {
            rotationCount = 0;
            if (clickswitch)
            {
                AudioManager.Instance.PlaySoundEffect(AudioIDs.GEARCLICK1);
            }
            else
            {
                AudioManager.Instance.PlaySoundEffect(AudioIDs.GEARCLICK2);
            }
            clickswitch = !clickswitch;
        }
        transform.rotation = rotation;
		foreach (Transform gear in gears)
		{
			gear.GetComponent<GearScript> ().RotateWithDifference (rotationDifference);
		}
		previousRotation = rotation;
	}
}