using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Player controller
/// </summary>
public class PlayerController : SingleMonoBase<PlayerController>, IStateMachineOwner
{
    public PlayerModel playerModel;

    private StateMachine stateMachine;

    public InputSystem inputActions;

    public float rotationSpeed = 8f;

    public float evadeTimer = 1f;

    [HideInInspector] public Vector2 inputMoveVec2;

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new StateMachine(this);
        inputActions = new InputSystem();
    }

    private void Start()
    {
        LockCursor();
        SwitchState(PlayerState.Idle);
    }
    private void Update()
    {
        inputMoveVec2 = inputActions.Player.Move.ReadValue<Vector2>().normalized;

        if (evadeTimer < 1f)
            evadeTimer += Time.deltaTime;

        if (evadeTimer > 1f)
        {
            evadeTimer = 1f;
        }
    }
    /// <summary>
    /// Switch state
    /// </summary>
    /// <param name="playerState">player state</param>
    public void SwitchState(PlayerState playerState)
    {
        switch (playerState)
        {
            case PlayerState.Idle:
                stateMachine.EnterState<PlayerIdleState>();
                break;
            case PlayerState.Run:
                stateMachine.EnterState<PlayerRunState>();
                break;
            case PlayerState.RunEnd:
                stateMachine.EnterState<PlayerRunEndState>();
                break;
            case PlayerState.TurnBack:
                stateMachine.EnterState<PlayerTurnBackState>();
                break;
            case PlayerState.Evade_Front:
            case PlayerState.Evade_Back:    //向前动画不执行 状态一直是 Evade_Back 并不能转成 Evade_Front
                if (evadeTimer != 1) return;
                stateMachine.EnterState<PlayerEvadeState>();
                evadeTimer -= 1f;
                break;
            case PlayerState.EvadeEnd:
                stateMachine.EnterState<PlayerEvadeEndState>();
                break;
        }

        playerModel.state = playerState;
    }

    /// <summary>
    /// Play Animation
    /// </summary>
    /// <param name="animationName">Animation Name</param>
    /// <param name="fixedTransitionDuration">Duration</param>
    public void PlayerAnimation(string animationName, float fixedTransitionDuration = 0.25f)
    {
        playerModel.animator.CrossFadeInFixedTime(animationName, fixedTransitionDuration);
    }

    /// <summary>
    /// Play Animation 过渡到动画
    /// </summary>
    /// <param name="animationName">Animation Name</param>
    /// <param name="fixedTransitionDuration">Duration</param>
    /// <param name="fixedTimeOffset">Animation start offset</param>
    public void PlayerAnimation(string animationName, float fixedTransitionDuration, float fixedTimeOffset)
    {
        playerModel.animator.CrossFadeInFixedTime(animationName, fixedTransitionDuration, 0, fixedTimeOffset);
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
}
