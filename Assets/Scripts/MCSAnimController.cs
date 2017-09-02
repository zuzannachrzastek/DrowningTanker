using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCSAnimController : MonoBehaviour {

    private Animator animator;
    private float walking;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        walking = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        walking = Input.GetAxis("Vertical");
        animator.SetFloat("walking", walking);
	}
}
