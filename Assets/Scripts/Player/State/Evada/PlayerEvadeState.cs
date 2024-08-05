using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
/// <summary>
/// Evade state ����״̬
/// </summary>
public class PlayerEvadeState : PlayerStateBase
{
    public override void Enter()
    {
        base.Enter();
        #region �ж�ǰ������

        switch (playerModel.currentState)
        {
            case PlayerState.Evade_Front:
                playerController.PlayerAnimation("Evade_Front");
                break;
            case PlayerState.Evade_Back:
                playerController.PlayerAnimation("Evade_Back");
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

        #region �ж϶����Ƿ����

        if (IsAnimationEnd())
        {
            switch (playerModel.currentState)
            {
                case PlayerState.Evade_Front:
                    if (playerController.inputActions.Player.Evade.IsPressed())
                    {
                        playerController.SwitchState(PlayerState.Run);
                        return;
                    }
                    playerController.SwitchState(PlayerState.Evade_Front_End);
                    break;
                case PlayerState.Evade_Back:
                    playerController.SwitchState(PlayerState.Evade_Back_End);
                    break;
            }
            return;
        }

        #endregion

    }
}
