using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HandX : MonoBehaviour
{
    //Animation
    public float animationSpeed;

    Animator animator;
    public SkinnedMeshRenderer mesh;
    public GameObject armature;
    private float gripTarget;
    private float triggerTarget;
    private float gripCurrent;
    private float triggerCurrent;
    private string animatorGripParam = "Grip";
    private string animatorTriggerParam = "Trigger";

    // Physics movement
    [SerializeField] private GameObject followObject;
    [SerializeField] private float followSpeed = 30f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;
    private Transform _followTarget;
    private Rigidbody _body;

    // Start is called before the first frame update
    void Start()
    {
        // Animation
        animator = GetComponent<Animator>();
        //mesh = GetComponentInChildren<SkinnedMeshRenderer>();

        // Physics movement
        _followTarget = followObject.transform;
        _body = GetComponent<Rigidbody>();
        _body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        _body.interpolation = RigidbodyInterpolation.Interpolate;
        _body.mass = 20f;

        // Teleport hands
        _body.position = _followTarget.position;
        _body.rotation = _followTarget.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand();
        PhysicsMove();
    }

    private void PhysicsMove()
    {
        //Update postition
        var positionWithOffeset = _followTarget.position + positionOffset;
        var distance = Vector3.Distance(positionWithOffeset, transform.position);
        _body.velocity = (_followTarget.position - transform.position).normalized * (followSpeed * distance);

        //Update rotation
        var rotationWithOffset = _followTarget.rotation * Quaternion.Euler(rotationOffset);
        var q = rotationWithOffset * Quaternion.Inverse(_body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);
        _body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);
    }

    internal void SetGrip(float v)
    {
        gripTarget = v;

    }

    internal void SetTrigger(float v)
    {
        triggerTarget = v;
    }

    void AnimateHand()
    {
        if (gripCurrent != gripTarget)
        {
            Debug.Log("Grip");
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * animationSpeed);
            animator.SetFloat(animatorGripParam, gripCurrent);
        }
        if (triggerCurrent != triggerTarget)
        {
            Debug.Log("Trigger");
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * animationSpeed);
            animator.SetFloat(animatorTriggerParam, triggerCurrent);
        }
    }

    void ToggleVisibility()
    {
        Debug.Log("Toggle hand visibility");
        mesh.enabled = !mesh.enabled;
        foreach(Collider c in GetComponentsInChildren<Collider>())
        {
            if(!c.enabled)
            {
                c.enabled = !c.enabled;
            }
            else
            {
                c.enabled = !c.enabled;
            }
            
        }
    }
}
