using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunEndState : PlayerStateBase
{
    public override void Enter()
    {
        base.Enter();

        #region �ж����ҽ�

        switch (playerModel.foot)
        {
            case ModelFoot.Right:
                playerController.PlayerAnimation("Run_End_R", .1f);
                break;
            case ModelFoot.Left:
                playerController.PlayerAnimation("Run_End_L", .1f);
                break;
        }

        #endregion
    }

    public override void Update()
    {
        base.Update();
        #region ������
        if (playerController.inputActions.Player.BigSkill.triggered)
        {
            playerController.SwitchState(PlayerState.BigSkillStart);
            return;
        }
        #endregion
        #region ��⹥��

        if (playerController.inputActions.Player.Fire.triggered)
        {
            playerController.SwitchState(PlayerState.NormalAttack);
            return;
        }
        #endregion

        #region �������
        //                                                 ����
        if (playerController.inputActions.Player.Evade.triggered)
        {
            playerController.SwitchState(PlayerState.Evade_Back);
            return;
        }

        #endregion

        #region �ƶ����
        if (playerController.inputMoveVec2 != Vector2.zero)
        {
            playerController.SwitchState(PlayerState.Walk);
            return;
        }
        #endregion


        #region �ж϶����Ƿ����
        if (IsAnimationEnd())
        {
            playerController.SwitchState(PlayerState.Idle);
            return;
        }

        #endregion

    }

}
