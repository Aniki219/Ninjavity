using System;
using UnityEngine;

public class DoGravity : PlayerStateBehavior {
    public override void Update() {
        int gravDir = Math.Sign(pc.targetGravity.y);
        if (pc.gravity.y < pc.targetGravity.y) {
            pc.gravity += Vector2.up * Time.deltaTime * pc.gravityLerpTime;
        }
        if (pc.gravity.y > pc.targetGravity.y) {
            pc.gravity -= Vector2.up * Time.deltaTime * pc.gravityLerpTime;
        }
        if (pc.IsGrounded()) {
            pc.gravity = gravDir * 0.1f * Vector2.up;
        }

        if (gravDir < 0 && pc.gravity.y > 0 && cc.collisionState.above ||
            gravDir > 0 && pc.gravity.y < 0 && cc.collisionState.below) {
            pc.gravity /= 2;
        }

        cc.velocity += pc.gravity;
    }
}
        