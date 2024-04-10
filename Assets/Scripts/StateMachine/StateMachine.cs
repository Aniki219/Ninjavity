using System;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour {
    public enum PhaseEnum {
        START,
        UPDATE,
        EXIT
    }

    public PhaseEnum phase {get; protected set;}

    public State initialState;
    protected State activeState;
    protected State nextState;

    protected virtual void Start() {
        activeState = initialState;
        activeState.Attach(this);
        phase = PhaseEnum.START;
    }

    protected void Update() {
        if (phase.Equals(PhaseEnum.UPDATE)) {
            activeState.behaviors.ForEach(b => b.Update());
            activeState.transitions.ForEach(t => t.checkCondition());
        }
        if (phase.Equals(PhaseEnum.START)) {
            OnStartPhase();
            activeState.behaviors.ForEach(b => b.Start());
            phase = PhaseEnum.UPDATE;
        }   
        if (phase.Equals(PhaseEnum.EXIT)) {
            activeState.behaviors.ForEach(b => b.Exit());
            activeState = nextState;
            phase = PhaseEnum.START;
        }
    }

    public void ChangeState<T>() where T : State {
        nextState = (T) Activator.CreateInstance(typeof(T));
        nextState.Attach(this);
        phase = PhaseEnum.EXIT;
    }

    protected virtual void OnStartPhase() {

    }
}

public abstract class EntityStateMachine : StateMachine {
    [HideInInspector]
    public CharacterController2D cc;
    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public SpriteRenderer sprite;
    
    private void Awake() {
        cc = GetComponent<CharacterController2D>();
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    protected override void OnStartPhase() {
        anim.Play(activeState.GetType().Name);
    }
}