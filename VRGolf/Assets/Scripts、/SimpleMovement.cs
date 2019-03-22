using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour {
    public GameObject wedge;
    public Vector3 wedgeVelocity;
    public Vector3 heightAdjustment;
    private Transform wedgeTransform;
    private Rigidbody ballRigidbody;
    private Vector3 lastPosition;
    private Vector3 currentPosition;
    private TrailRenderer ballTrailRenderer;

    

	// Use this for initialization
	void Start () {
        ballRigidbody = GetComponent<Rigidbody>();
        lastPosition = wedge.transform.position;
        ballTrailRenderer = GetComponent<TrailRenderer>();
        ballTrailRenderer.enabled = false;
        
	}
	
	// Update is called once per frame
	void Update () {
        currentPosition = wedge.transform.position;
        wedgeVelocity = (currentPosition - lastPosition) / Time.deltaTime;
        lastPosition = currentPosition;
        Fraction();
	}

    void Fraction()
    {
        if(ballRigidbody.velocity.magnitude != 0)
        {
            ballRigidbody.AddForce(new Vector3(ballRigidbody.velocity.x, 0, ballRigidbody.velocity.z) * -0.5f);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("The ball has been in contact with " + collision.collider.tag);
        if (collision.collider.tag == "Wedge")
        {
            ballRigidbody.velocity = wedgeVelocity * 20 + heightAdjustment * wedgeVelocity.magnitude;
            ballTrailRenderer.enabled = true;
            AudioSource ballSwingAudio;
            ballSwingAudio = GetComponent<AudioSource>();
            ballSwingAudio.Play();
        }
    }
}
