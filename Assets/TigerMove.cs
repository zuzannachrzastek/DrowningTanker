using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerMove : MonoBehaviour {

    public Vector3 positionB;
    public float speed;

    public float stepLenght = 0.01f;

    private Animator animator;
    private float walking;
    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        walking = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {

        if(transform.position.equals(positionB))
        {
            walking = -1;
            animator.SetFloat("walking", walking);
        }
        //float walking = animator.GetFloat("walking");
        walking = 1;
        animator.SetFloat("walking", walking);
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, positionB, step);
    }
}
