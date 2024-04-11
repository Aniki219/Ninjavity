using States;
using UnityEngine;

public class CanFlip : StateTransition {
    public override void checkCondition() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            state.stateMachine.ChangeState<Flip>();
        }
    }
}