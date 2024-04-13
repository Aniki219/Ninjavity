using States;
using UnityEngine;

public class CanRun : PlayerTransition {
    public override void checkCondition() {
        if (!Mathf.Approximately(cc.velocity.x, 0)) {
            pc.ChangeState<Run>();
        }
    }
}

public class CanIdle : PlayerTransition {
    public override void checkCondition() {
        if (Mathf.Approximately(cc.velocity.x, 0)) {
            pc.ChangeState<Grounded>();
        }
    }
}