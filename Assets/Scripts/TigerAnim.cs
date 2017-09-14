using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerAnim : MonoBehaviour {

    // Zuzanna Chrzastek and Maciej Makowka, 2017

    [Tooltip("The tiger step length.")]
    public float stepLenght = 0.01f;
    [Tooltip("The state name for tiger walking. Name could be got from the tiger Animator screen. Default name is `walk`")]
    public String animatorStateNameForWalk = "walk";
    [Tooltip("Locking the tiger rotation. This prevents tiger from falling in X and Z axis. Default is true - enabled protection.")]
    public bool lockRotationXZ = true;
    
    public GameObject aim;
    public bool runToAim = false;

    private Animator animator;
    private float walking;
    private AnimatorStateInfo animatorState;
    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        walking = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {

        float walking = animator.GetFloat("walking");
        animatorState = animator.GetCurrentAnimatorStateInfo(0);
        if (animatorState.IsName(animatorStateNameForWalk))
        {
            /* our old script
            float move_x;
            float move_y;
            float angle;
            double rad;

            angle = transform.rotation.y;
            rad = angle * (Math.PI / 180);
            move_x = Convert.ToSingle(stepLenght / Math.Pow(Math.Sqrt(1.0 + Math.Tan(rad)), 2));
            move_y = Convert.ToSingle(move_x * Math.Tan(rad));
            transform.Translate(new Vector3(move_y, 0, move_x));            
            */

            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * stepLenght);

            if (lockRotationXZ)
            {
                Vector3 eulerAngles = transform.rotation.eulerAngles;
                eulerAngles = new Vector3(0, eulerAngles.y, 0);
                transform.rotation = Quaternion.Euler(eulerAngles);
            }
        }

        if (runToAim)
        {
            Vector3 aimPosition = aim.transform.position;
            float dist = Vector3.Distance(aimPosition, gameObject.transform.position);

            //double rad = Math.Atan(Math.Abs(Math.Abs(aimPosition.x) - Math.Abs(transform.position.x)) / dist);
            //float degree = Convert.ToSingle(rad * 180 / Math.PI);
            //Debug.Log(degree);
            //Vector3 eulerAngles = transform.rotation.eulerAngles;
            //eulerAngles = new Vector3(eulerAngles.x, degree, eulerAngles.z);
            //transform.rotation = Quaternion.Euler(eulerAngles);
            Vector3 direction = aimPosition - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 10 * stepLenght * Time.deltaTime);

            if (dist > 1.20)
            {
                float step = stepLenght * Time.deltaTime;               
                transform.position = Vector3.MoveTowards(transform.position, aimPosition, step);
                animator.SetFloat(animatorStateNameForWalk, 0.8f);
            } else
            {
                animator.SetFloat(animatorStateNameForWalk, 0.0f);
            }


        }
   
	}

    void OnCollisionExit(Collision collisionInfo)
    {
        print("No longer in contact with " + collisionInfo.transform.name);
    }

}
