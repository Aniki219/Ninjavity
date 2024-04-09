using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4f;

    CharacterController2D cc;
    Animator anim;

    Vector2 gravity;
    Vector2 startGravity;
    Vector2 _targetGravity;
    public Vector2 TargetGravity {get {return _targetGravity;} set {
        startGravity = gravity;
        _targetGravity = value;
        gravitySwapTime = Time.time;
    }}
    float gravitySwapTime;

    public float gravityLerpTime = 2.5f;
    public float gravityMagnitude;

    Vector2 gravitySmoothing;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController2D>();
        anim = GetComponent<Animator>();
        TargetGravity = Vector2.down * gravityMagnitude;
    }

    void Update()
    {
        DoGravity();

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            TargetGravity = Vector2.up * gravityMagnitude;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            TargetGravity = Vector2.down * gravityMagnitude;
        }

        cc.velocity = Vector2.right * Input.GetAxisRaw("Horizontal") * speed;
        cc.velocity += gravity;

        //anim.Play(state);
    }

    void DoGravity() {
        if (gravity.y < TargetGravity.y) {
            gravity += Vector2.up * Time.deltaTime * gravityLerpTime;
        }
        if (gravity.y > TargetGravity.y) {
            gravity -= Vector2.up * Time.deltaTime * gravityLerpTime;
        }
        if (IsGrounded()) {
            gravity = Vector2.zero;
        }

        if (TargetGravity.y < 0 && gravity.y > 0 && cc.collisionState.above) {
            gravity /= 2;
        }
    }

    bool IsGrounded() {
        if (TargetGravity.y == 0) return false;
        return TargetGravity.y < 0 ? cc.collisionState.below : cc.collisionState.above;
    }
}
