using States;
using UnityEngine;

public class FlipGravity : PlayerStateBehavior {
    private readonly Vector2 flipDirection;

    public FlipGravity(Vector2 _flipDirection):base() {
        flipDirection = _flipDirection;
    }

    public override void Start() {
        pc.targetGravity = flipDirection * pc.gravityMagnitude;
        pc.sprite.flipY = flipDirection.y >= 0;
    }
}