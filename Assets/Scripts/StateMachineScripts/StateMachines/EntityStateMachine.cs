using UnityEngine;

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

    protected override void OnStateStart()
    {
        SetAnimationState();
        base.OnStateStart();
    }

    protected void SetAnimationState() {
        string stateName = activeState.GetType().Name;
        if (activeState.animationStateOverride != null) {
            stateName = activeState.animationStateOverride;
        }
        anim.Play(stateName);
    }
}