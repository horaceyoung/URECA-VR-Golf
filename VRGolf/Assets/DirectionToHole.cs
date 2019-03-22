using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class DirectionToHole : MonoBehaviour {
    public GameObject ballHole;

    private Transform headsetTransform;
    private Vector3 headsetPosition;
    private Transform ballHoleTransform;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        headsetTransform = VRTK_DeviceFinder.DeviceTransform(VRTK_DeviceFinder.Devices.Headset);
        headsetPosition = headsetTransform.position;
        ballHoleTransform = ballHole.transform;
        Vector3 relativePos = ballHoleTransform.position - transform.position;
        transform.position = headsetPosition + new Vector3(0.7f, -0.5f, 0.2f);
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        Quaternion targetRotation = Quaternion.Euler(rotation.eulerAngles + new Vector3(-10, 180, 0));
        transform.rotation = targetRotation;


	}
}
