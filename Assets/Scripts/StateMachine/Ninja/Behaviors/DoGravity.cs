using UnityEngine;

public class DoGravity : StateBehavior {
    CharacterController2D cc;
    PlayerController pc;

    protected override void AttachComponents() {
        pc = state.stateMachine as PlayerController;
        cc = pc.cc;
    }

    public override void Update() {
        if (pc.gravity.y < pc.targetGravity.y) {
            pc.gravity += Vector2.up * Time.deltaTime * pc.gravityLerpTime;
        }
        if (pc.gravity.y > pc.targetGravity.y) {
            pc.gravity -= Vector2.up * Time.deltaTime * pc.gravityLerpTime;
        }
        if (pc.IsGrounded()) {
            pc.gravity = Vector2.zero;
        }

        if (pc.targetGravity.y < 0 && pc.gravity.y > 0 && cc.collisionState.above) {
            pc.gravity /= 2;
        }

        cc.velocity += pc.gravity;
    }
}
        