using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : Singleton<RotationManager> {

    public Transform knob;

    public override void Init()
    {
        knob = GameObject.Find("RotateKnob").transform;
    }

    //use same rotation as the knob (called if the reverse bool on the gear is unchecked) 
    public void Rotate(float Multiplier)
    {
        this.transform.eulerAngles = knob.GetComponent<RotationController>().getEulerRot(knob.eulerAngles) * Multiplier;
    }

    //use opposite rotation as the knob (called if the reverse bool on the gear is checked)
    public void CounterRotate(float Multiplier)
    { 
        this.transform.eulerAngles = knob.GetComponent<RotationController>().getEulerRot(knob.eulerAngles) * -Multiplier;
	}
}
