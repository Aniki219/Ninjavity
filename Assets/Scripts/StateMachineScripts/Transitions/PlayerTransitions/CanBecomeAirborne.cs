using States;
using UnityEngine;

public class CanBecomeAirborn : PlayerTransition {
    public override void checkCondition() {
        if (!pc.IsGrounded()) {
            pc.ChangeState<Airborne>();
        }
    }
}