using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBuoyancy : MonoBehaviour {
    private Vector3 _lastVelocity;
    public Rigidbody g0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
  
    }

    internal void Setup()
    {
        g0 = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var depth = Mathf.Max(0, transform.position.y - g0.transform.position.y+1);
        var f = Mathf.Min(depth * 5f, Mathf.Abs(Physics.gravity.y) * 3.5f);
        g0.AddForce( f * Vector3.up, ForceMode.Acceleration);
        _lastVelocity = g0.velocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Dupa");
        //ContactPoint contact = collision.contacts[0];
        //if (contact.normal.y <= -0.6f)
        //{
        //    g0.isKinematic = true;
        //    collision.transform.position = contact.point - _lastVelocity.normalized * 30; // approximation of the radius of the object
        //}
    }

}
