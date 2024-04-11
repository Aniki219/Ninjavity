using States;
using UnityEngine;

public class CanRun : StateTransition {
    public override void checkCondition() {
        if (!Mathf.Approximately((state.stateMachine as PlayerStateMachine).cc.velocity.x, 0)) {
            state.stateMachine.ChangeState<Run>();
        }
    }
}

public class CanIdle : StateTransition {
    public override void checkCondition() {
        if (Mathf.Approximately((state.stateMachine as PlayerStateMachine).cc.velocity.x, 0)) {
            state.stateMachine.ChangeState<Grounded>();
        }
    }
}