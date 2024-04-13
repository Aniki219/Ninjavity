using System.Collections.Generic;
using UnityEngine;

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
                new CanLand()
            };
        }
    }

    public abstract class Flip : PlayerState {
        public Flip():base() {
            animationStateOverride = "Flip";
            
            transitions = new List<StateTransition>() {
                new OnAnimationEnd<Airborne>(),
                new CanLand(),
            };            
        }
    }
    
    public class FlipUp : Flip {
        public FlipUp() : base() {
            behaviors.Add(new FlipGravity(Vector2.up));
        }
    }

    public class FlipDown : Flip {
        public FlipDown() : base() {
            behaviors.Add(new FlipGravity(Vector2.down));
        }
    }
}