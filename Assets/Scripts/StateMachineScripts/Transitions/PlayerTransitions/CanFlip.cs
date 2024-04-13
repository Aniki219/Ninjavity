using States;
using UnityEngine;

public class CanFlip : PlayerTransition {
    public override void checkCondition() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            pc.ChangeState<FlipUp>();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            pc.ChangeState<FlipDown>();
        }
    }
}