using System.Collections.Generic;

namespace States {
    public class PlayerState : State {
        public PlayerState() {
            List<StateBehavior> defaultBehaviors = new List<StateBehavior>(){
                new MoveWithArrows(),
                new FaceMovementDirection(),
                new FlipGravity(),
                new DoGravity(),
            };

            behaviors.AddRange(defaultBehaviors);
        }
    }
}