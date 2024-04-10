using System.Collections.Generic;

namespace States
{
    public class Grounded : PlayerState {
        public Grounded():base() {
            transitions = new List<StateTransition>() {
                new CanRun(),
            };
        }
    }

    public class Run : PlayerState {
        public Run():base() {
            transitions = new List<StateTransition>() {
                new CanIdle(),
            };
        }
    }
}