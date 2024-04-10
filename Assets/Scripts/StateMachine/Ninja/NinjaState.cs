
using System.Collections.Generic;

public class NinjaState : State {
    public NinjaState() {
        List<StateBehavior> defaultBehaviors = new List<StateBehavior>(){
            new DoGravity(),
            new FlipGravity(),
            new MoveWithArrows(),
        };

        behaviors.AddRange(defaultBehaviors);
    }
}