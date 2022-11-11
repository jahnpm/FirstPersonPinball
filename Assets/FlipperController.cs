using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour {

    HingeJoint hJointRight, hJointLeft;
    private Rigidbody rbRight, rbLeft;

	// Use this for initialization
	void Start () {

        hJointRight = transform.Find("RightFlipper").gameObject.GetComponent<HingeJoint>();
        hJointLeft = transform.Find("LeftFlipper").gameObject.GetComponent<HingeJoint>();

        rbRight = transform.Find("RightFlipper").gameObject.GetComponent<Rigidbody>();
        rbLeft = transform.Find("LeftFlipper").gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKey(KeyCode.D))
            rbRight.AddForce(Quaternion.Euler(-30, 0, 0) * Vector3.forward * 300, ForceMode.Acceleration);

        if (Input.GetKey(KeyCode.A))
            rbLeft.AddForce(Quaternion.Euler(-30, 0, 0) * Vector3.forward * 300, ForceMode.Acceleration);
    }
}
