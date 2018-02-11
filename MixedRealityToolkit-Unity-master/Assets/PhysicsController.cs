using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour {

    public float power = 10.0f;
    Rigidbody rb;
    public float angularPower = 100;
    public bool useCamera;
    private GameObject owner;
    public string walkAxisName, straphAxisName,flyAxisName,yawAxisName;
    //Create Axis for MR controllers in input Manager

	// Use this for initialization
	void Start () {
        if (useCamera)
        {
            owner = Camera.main.gameObject;
        }
        else
        {
            owner = this.gameObject;
        }

        rb = this.gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame

    void Walk(float units)
    {
        rb.AddForce(owner.transform.forward * units);
        Debug.Log("Walking");
    }

    void Straph(float units)
    {
        rb.AddForce(owner.transform.right* units);
    }

    void Yaw(float units)
    {
        rb.AddTorque(Vector3.up * units);
    }

    void Fly(float units)
    {
        rb.AddForce(owner.transform.up * units);
    }

    void FixedUpdate () {
        float walking = Input.GetAxis(walkAxisName);
        float straph = Input.GetAxis(straphAxisName);
        float yaw = Input.GetAxis(yawAxisName);
        float fly = Input.GetAxis(flyAxisName);

        Yaw(yaw * angularPower * Time.deltaTime);
        Fly(fly * power * Time.deltaTime);
        Walk(walking * power * Time.deltaTime);
        Straph(straph * power * Time.deltaTime);
    }
}
