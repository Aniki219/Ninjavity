using States;
using UnityEngine;

public class CanLand : PlayerTransition {
    public override void checkCondition() {
        if (pc.IsGrounded()) {
            pc.ChangeState<Grounded>();
        }
    }
}