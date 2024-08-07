using System;
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

    public PlayerConfig playerConfig;

    public float rotationSpeed = 8f;

    public float evadeTimer = 1f;

    [HideInInspector] public Vector2 inputMoveVec2;
    //���
    [HideInInspector] public List<PlayerModel> controllableModels;
    //��ǰ�ٿصĽ�ɫ�±�
    private int currentModeIndex;
    //���˱�ǩ�б�
    public List<string> enemyTagList;

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new StateMachine(this);
        inputActions = new InputSystem();
        controllableModels = new List<PlayerModel>();

        #region ���ɽ�ɫģ��

        for (int i = 0; i < playerConfig.models.Length; i++)
        {
            GameObject model = Instantiate(playerConfig.models[i], transform);
            controllableModels.Add(model.GetComponent<PlayerModel>());
            model.SetActive(false);
            controllableModels[i].Init(enemyTagList);
        }

        #endregion

        #region �ٿ���ӵĵ�һ����ɫ

        currentModeIndex = 0;
        controllableModels[currentModeIndex].gameObject.SetActive(true);
        playerModel = controllableModels[currentModeIndex];

        #endregion

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
        playerModel.currentState = playerState;
        switch (playerState)
        {
            case PlayerState.Idle:
            case PlayerState.Idle_AFK:
                stateMachine.EnterState<PlayerIdleState>(true);
                break;
            case PlayerState.Walk:
            case PlayerState.Run:
                stateMachine.EnterState<PlayerRunState>(true);
                break;
            case PlayerState.RunEnd:
                stateMachine.EnterState<PlayerRunEndState>();
                break;
            case PlayerState.TurnBack:
                stateMachine.EnterState<PlayerTurnBackState>();
                break;
            case PlayerState.Evade_Front:
            case PlayerState.Evade_Back:    //��ǰ������ִ�� ״̬һֱ�� Evade_Back ������ת�� Evade_Front
                if (evadeTimer != 1) return;
                stateMachine.EnterState<PlayerEvadeState>();
                evadeTimer -= 1f;
                break;
            case PlayerState.Evade_Front_End:
            case PlayerState.Evade_Back_End:
                stateMachine.EnterState<PlayerEvadeEndState>();
                break;
            case PlayerState.NormalAttack:
                stateMachine.EnterState<PlayerNormalAttackState>(true);
                break;
            case PlayerState.NormalAttackEnd:
                stateMachine.EnterState<PlayerNormalAttackEndState>();
                break;
            case PlayerState.BigSkillStart:
                stateMachine.EnterState<PlayerSkillBigStartState>();
                break;
            case PlayerState.BigSkill:
                stateMachine.EnterState<PlayerSkillBigState>();
                break;
            case PlayerState.BigSkillEnd:
                stateMachine.EnterState<PlayerSkillBigEndState>();
                break;
            case PlayerState.SwitchInNormal:
                stateMachine.EnterState<PlayerSwitchInState>();
                break;
        }
    }

    public void SwitchNextModel()
    {
        //ˢ��״̬��
        stateMachine.Clear();

        //�˳���ǰģ��
        playerModel.Exit();

        #region ������һ��ģ��
        currentModeIndex++;
        currentModeIndex %= controllableModels.Count;
        PlayerModel nextmodel = controllableModels[currentModeIndex];
        nextmodel.gameObject.SetActive(true);

        Vector3 pos = playerModel.transform.position;
        Quaternion rot = playerModel.transform.rotation;

        playerModel = nextmodel;
        #endregion

        playerModel.Enter(pos, rot);
        //�л����볡״̬
        SwitchState(PlayerState.SwitchInNormal);
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
    /// Play Animation ���ɵ�����
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
