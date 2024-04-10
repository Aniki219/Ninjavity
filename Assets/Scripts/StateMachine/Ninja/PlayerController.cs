using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : StateMachine
{
    public float moveSpeed = 4f;

    [HideInInspector]
    public CharacterController2D cc;
    [HideInInspector]
    public Animator anim;

    public Vector2 gravity;
    public Vector2 targetGravity;

    public float gravityLerpTime = 2.5f;
    public float gravityMagnitude;

    // Start is called before the first frame update
    protected override void Start()
    {
        cc = GetComponent<CharacterController2D>();
        anim = GetComponent<Animator>();
        targetGravity = Vector2.down * gravityMagnitude;
        initialState = new States.Grounded();
        base.Start();
    }

    public bool IsGrounded() {
        if (targetGravity.y == 0) return false;
        return targetGravity.y < 0 ? cc.collisionState.below : cc.collisionState.above;
    }
}
