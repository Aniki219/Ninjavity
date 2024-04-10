using UnityEngine;

public class FlipGravity : PlayerStateBehavior {
    public override void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            pc.targetGravity = Vector2.up * pc.gravityMagnitude;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            pc.targetGravity = Vector2.down * pc.gravityMagnitude;
        }
    }
}