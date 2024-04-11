using System.Collections.Generic;

namespace States
{
    public class PlayerState : State {
        public PlayerState() {
            List<StateBehavior> defaultBehaviors = new List<StateBehavior>(){
                new MoveWithArrows(),
                new FaceMovementDirection(),
                new DoGravity(),
            };

            behaviors.AddRange(defaultBehaviors);
        }
    }

    public class Grounded : PlayerState {
        public Grounded():base() {
            transitions = new List<StateTransition>() {
                new CanRun(),
                new CanFlip(),
                new CanBecomeAirborn(),
            };
        }
    }

    public class Run : Grounded {
        public Run():base() {
            transitions.Remove(transitions.Find(t => t.GetType().Equals(typeof(CanRun))));
            transitions.Add(new CanIdle());
        }
    }

    public class Airborne : PlayerState {
        public Airborne():base() {
            transitions = new List<StateTransition>() {
                new CanFlip(),
            };
        }
    }

    public class Flip : PlayerState {
        public Flip():base() {
            transitions = new List<StateTransition>() {
                new OnAnimationEnd<Airborne>()
            };
        }
    }
}