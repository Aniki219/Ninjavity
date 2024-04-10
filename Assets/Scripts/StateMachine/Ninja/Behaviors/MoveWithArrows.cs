using UnityEngine;

public class MoveWithArrows : StateBehavior {
    PlayerController pc;
    CharacterController2D cc;
    float moveSpeed;

    protected override void AttachComponents() {
        pc = state.stateMachine as PlayerController;
        cc = pc.cc;
        moveSpeed = pc.moveSpeed;
    }

    public override void Update() {
        cc.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, cc.velocity.y);
    }
}