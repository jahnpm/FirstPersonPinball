using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    public Transform table;
    public Text scoreText;

    Rigidbody rb;

    private Vector3 cameraDirection;
    private bool startPosition;
    private int score = 0;
    private bool resetScore = false;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        cameraDirection = Vector3.forward;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Camera.main.transform.position = rb.position;
        cameraDirection = Vector3.RotateTowards(cameraDirection,
            rb.velocity.normalized, 3 * Time.fixedDeltaTime, 0).normalized;
        Camera.main.transform.LookAt(Camera.main.transform.position + cameraDirection);

        if (Input.GetKey(KeyCode.Space) && startPosition)
        {
            rb.AddForce(Quaternion.Euler(-30, 0, 0) * Vector3.forward * 5, ForceMode.VelocityChange);

            if (resetScore)
                score = 0;
        }

        scoreText.text = "Score: " + score;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("OneScorer"))
            score++;

        if (collision.gameObject.CompareTag("TwoScorer"))
            score += 5;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "StartTrigger")
            startPosition = true;

        if (other.name == "ResetTrigger")
            resetScore = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "StartTrigger")
            startPosition = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "StartTrigger")
            startPosition = false;
    }
}
