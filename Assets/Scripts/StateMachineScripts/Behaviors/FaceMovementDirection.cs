using UnityEngine;

public class FaceMovementDirection : PlayerStateBehavior {
    public override void Update() {
        if (!Mathf.Approximately(cc.velocity.x, 0)) {
            pc.sprite.flipX = cc.velocity.x < 0;
        }
    }
}
        