using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class ControllerEventListener : MonoBehaviour {
    public Vector3 rotationAmplitude;
    private GameObject wedge;

    // Use this for initialization
	void Start () {
        GetComponent<VRTK_ControllerEvents>().GripPressed += new ControllerInteractionEventHandler(RotateGolfClub);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void RotateGolfClub(object sender, ControllerInteractionEventArgs e)
    {
        wedge = GetComponent<VRTK_InteractGrab>().GetGrabbedObject();
        Vector3 targetRotation = wedge.transform.rotation.eulerAngles + rotationAmplitude;
        wedge.transform.rotation = Quaternion.Euler(targetRotation);
        Debug.Log("Grip is pressed and target rotation is " + targetRotation);
    }
}
