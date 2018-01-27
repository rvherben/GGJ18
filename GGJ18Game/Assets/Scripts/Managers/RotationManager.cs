using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : Singleton<RotationManager> {

    public Transform knob;
    public float rotateMultiplier = 1f;

    public override void Init()
    {
        knob = GameObject.Find("RotateKnob").transform;
    }
    
    void Update () {
        this.transform.eulerAngles = knob.GetComponent<RotationController>().getEulerRot(knob.eulerAngles) * rotateMultiplier;
	}
}
