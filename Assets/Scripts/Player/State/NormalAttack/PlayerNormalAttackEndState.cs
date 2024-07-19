using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalAttackEndState : PlayerStateBase
{
    public override void Enter()
    {
        base.Enter();
        playerController.PlayerAnimation($"Attack_Normal_{playerModel.skillConfig.currentNormalAttackIndex}_End");
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
            //�ۼӹ�������
            playerModel.skillConfig.currentNormalAttackIndex++;
            if (playerModel.skillConfig.currentNormalAttackIndex
                > playerModel.skillConfig.normalAttackDamageMultiple.Length)
            {
                playerModel.skillConfig.currentNormalAttackIndex = 1;
            }
            //�л�����״̬
            playerController.SwitchState(PlayerState.NormalAttack);
            return;
        }

        #endregion

        #region �������

        if (playerController.inputActions.Player.Evade.triggered)
        {
            playerController.SwitchState(PlayerState.Evade_Back);
            playerModel.skillConfig.currentNormalAttackIndex = 1;
            return;
        }

        #endregion

        #region ��������

        if (playerController.inputMoveVec2 != Vector2.zero && animationPlayTime > 0.5f)
        {
            playerController.SwitchState(PlayerState.Run);
            playerModel.skillConfig.currentNormalAttackIndex = 1;
            return;
        }


        #endregion

        #region �ж϶����Ƿ����

        if (IsAnimationEnd())
        {
            playerController.SwitchState(PlayerState.Idle);
            playerModel.skillConfig.currentNormalAttackIndex = 1;
            return;
        }

        #endregion
    }

}
