using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class RealTimeMovementDetection : MonoBehaviour {
    private Vector3 headsetPosition;
    private Vector3 leftControllerPosition;
    private Vector3 rightControllerPosition;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        headsetPosition = VRTK_DeviceFinder.HeadsetTransform().position;
        leftControllerPosition = VRTK_DeviceFinder.GetControllerLeftHand().transform.position;
        rightControllerPosition = VRTK_DeviceFinder.GetControllerRightHand().transform.position;


        /*float angle1= Vector3.Angle(Vector3.up, leftControllerPosition-headsetPosition);
        float angle2= Vector3.Angle(Vector3.up, rightControllerPosition - headsetPosition);*/
        
    }
}

