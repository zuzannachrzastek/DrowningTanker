using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCSAnimController : MonoBehaviour {

    // Zuzanna Chrzastek and Maciej Makowka, 2017

    private Animator animator;
    private float walking;
    private float turning;
    private float jumping;

    // it makes turning independent of frame rate (fps). 
    public int turnSpeed;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        walking = 0.0f;
        turning = 0.0f;
        jumping = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {  
        walking = Input.GetAxis("Vertical");
        animator.SetFloat("walking", walking);
        turning = Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0.0f, turnSpeed * turning * Time.deltaTime));
        if (Input.GetKey(KeyCode.Space))
        {
            if (jumping < 1)
                jumping += 0.1f;
            else
                jumping = 1.0f;
        }
        else
        {
            if (jumping > 0)
                jumping -= 0.1f;
            else
                jumping = 0f;
        }
        animator.SetFloat("jumping", jumping);
       
    }
}
