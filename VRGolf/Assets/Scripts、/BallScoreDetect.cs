using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScoreDetect : MonoBehaviour {
    public GameObject golfBall;
    public Vector3 origialPos;

    private AudioSource scoreAudio;

	// Use this for initialization
	void Start () {
        scoreAudio = GetComponent<AudioSource>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Ball")
        {
            Debug.Log("The ball has been scored");
            scoreAudio.Play();
            Instantiate(golfBall, origialPos, Quaternion.identity);
            Destroy(golfBall);
        }
    }
}
