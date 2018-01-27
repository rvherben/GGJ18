using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : Singleton<RotationManager> {

    private Vector3 knobEuler;

    override public void Init()
    {
        Debug.Log("random");
        knobEuler = Vector3.zero;
    }

    //use same rotation as the knob (called if the reverse bool on the gear is unchecked) 
    public void Rotate(float Multiplier)
    {
        this.gameObject.transform.eulerAngles = knobEuler * Multiplier;
    }

    //use opposite rotation as the knob (called if the reverse bool on the gear is checked)
    public void CounterRotate(float Multiplier)
    { 
        this.gameObject.transform.eulerAngles = knobEuler * -Multiplier;
	}

    public void SetEuler(Vector3 euler)
    {
        knobEuler = euler;
    }
}
