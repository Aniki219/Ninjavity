using UnityEngine;

public class MoveWithArrows : PlayerStateBehavior {
    public override void Update() {
        cc.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * pc.moveSpeed, 0);
    }
}