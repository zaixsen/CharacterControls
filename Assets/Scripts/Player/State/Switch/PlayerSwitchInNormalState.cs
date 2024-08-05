using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitchInState : PlayerStateBase
{
    public override void Enter()
    {
        base.Enter();
        playerController.PlayerAnimation("SwitchIn_Normal", 0f);
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


        #region ��������
        if (playerController.inputMoveVec2 != Vector2.zero)
        {
            playerController.SwitchState(PlayerState.Walk);
            return;
        }
        #endregion


        #region �������

        if (playerController.inputActions.Player.Evade.triggered)
        {
            playerController.SwitchState(PlayerState.Evade_Back);
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
