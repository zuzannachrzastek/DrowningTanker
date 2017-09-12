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

    private Animator animator;
    private float walking;
    private AnimatorStateInfo animatorState; 

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        walking = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        float walking = animator.GetFloat("walking");
        animatorState = animator.GetCurrentAnimatorStateInfo(0);
        if (animatorState.IsName(animatorStateNameForWalk))
        {
            float move_x;
            float move_y;
            float angle;
            double rad;

            angle = transform.rotation.y;
            rad = angle * (Math.PI / 180);
            move_x = Convert.ToSingle(stepLenght / Math.Pow(Math.Sqrt(1.0 + Math.Tan(rad)), 2));
            move_y = Convert.ToSingle(move_x * Math.Tan(rad));
            transform.Translate(new Vector3(move_y,0, move_x));
        }
	}
}
