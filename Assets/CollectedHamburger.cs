using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedHamburger : MonoBehaviour {

    // Zuzanna Chrzastek and Maciej Makowka, 2017

    [Tooltip("The Y axis position below which the tiger will be notified about the aim to go for him.")]
    public float positionYTriggerTiger = 6.9f;
    [Tooltip("Animator state name for runToAim action.")]
    public string runToAimName = "runToAim";

    public Animator animator;

	// Use this for initialization
	void Start () {
        animator = GameObject.Find("tiger_idle").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = transform.position;
        if (position.y < positionYTriggerTiger)
        {
            animator.SetBool(runToAimName, true);
        } else
        {
            animator.SetBool(runToAimName, false);
        }
	}
}
