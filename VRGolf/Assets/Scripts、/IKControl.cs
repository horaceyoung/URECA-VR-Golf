using UnityEngine;
using System;
using System.Collections;
using VRTK;

[RequireComponent(typeof(Animator))]

public class IKControl : MonoBehaviour
{

    protected Animator animator;

    public bool ikActive = false;
    public Transform leftHandObj;
    public Transform rightHandObj;
    public Transform Headtransform;
    public Transform lookObj;
    public float multiplier = 0;

    private Transform headsetTransform;
    private Transform leftHandControllerTransform;
    private Transform rightHandControllerTransform;

    private Vector3 headsetPos;
    private Vector3 leftHandControllerPos;
    private Vector3 rightHandControllerPos;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        headsetTransform = VRTK_DeviceFinder.HeadsetTransform();
        headsetPos = headsetTransform.position;

        leftHandControllerTransform = VRTK_DeviceFinder.GetControllerLeftHand().transform;
        leftHandControllerPos = leftHandControllerTransform.position;

        rightHandControllerTransform = VRTK_DeviceFinder.GetControllerRightHand().transform;
        rightHandControllerPos = rightHandControllerTransform.position;
    }


    //a callback for calculating IK
    void OnAnimatorIK()
    {


        Debug.Log("OnAnimator is Called");
        if (animator)
        {

            //if the IK is active, set the position and rotation directly to the goal. 
            if (ikActive)
            {

                // Set the look target position, if one has been assigned
                if (lookObj != null)
                {
                    animator.SetLookAtWeight(1);
                    animator.SetLookAtPosition(lookObj.position);
                }

                if (leftHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                    Vector3 targetLeft = (headsetPos - leftHandControllerPos) * multiplier;
                    animator.SetIKPosition(AvatarIKGoal.LeftHand, Headtransform.position - targetLeft);
                }

                // Set the right hand target position and rotation, if one has been assigned
                if (rightHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    Vector3 targetRight = (headsetPos - rightHandControllerPos) * multiplier;
                    animator.SetIKPosition(AvatarIKGoal.RightHand, Headtransform.position - targetRight);
                }



            }

        }
    }
}