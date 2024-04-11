using States;
using UnityEngine;

public class CanBecomeAirborn : StateTransition {
    public override void checkCondition() {
        if (!(state.stateMachine as PlayerStateMachine).IsGrounded()) {
            state.stateMachine.ChangeState<Airborne>();
        }
    }
}