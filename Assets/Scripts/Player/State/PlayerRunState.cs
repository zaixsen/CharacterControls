using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerIdleState
{
    private Camera mainCamera;

    public override void Enter()
    {
        base.Enter();

        mainCamera = Camera.main;
        #region ���ҽ��ж�

        switch (playerModel.foot)
        {
            case ModelFoot.Right:
                playerController.PlayerAnimation("Run", 0.25f, 0.25f);
                playerModel.foot = ModelFoot.Left;
                break;
            case ModelFoot.Left:
                playerController.PlayerAnimation("Run", 0.25f, 0);
                playerModel.foot = ModelFoot.Right;
                break;
        }
        #endregion
    }

    public override void Update()
    {
        base.Update();

        #region ��⹥��
        #endregion

        #region ������

        if (playerController.inputMoveVec2 == Vector2.zero)
        {
            playerController.SwitchState(PlayerState.RunEnd);
        }

        #endregion

        #region �������

        if (playerController.inputActions.Player.Evade.IsPressed())
        {
            playerController.SwitchState(PlayerState.Evade_Front);
        }

        #endregion

        #region �����ƶ�����

        if (playerController.inputMoveVec2 != Vector2.zero)
        {
            Vector3 inputMoveVec3 = new Vector3(playerController.inputMoveVec2.x, 0, playerController.inputMoveVec2.y);

            //Get main camera eulerAngles y
            float cameraAxisY = mainCamera.transform.eulerAngles.y;

            //��Ԫ�� * ����  ��ѧ��ʽ  ��ʱ���о�һ��
            Vector3 targetDir = Quaternion.Euler(0, cameraAxisY, 0) * inputMoveVec3;

            Quaternion targetQua = Quaternion.LookRotation(targetDir);

            float angles = Mathf.Abs(targetQua.eulerAngles.y - playerModel.transform.eulerAngles.y);

            if (angles > 177.5f && angles < 182.5f)
            {
                playerController.SwitchState(PlayerState.TurnBack);
            }
            else
            {
                playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation,
                    targetQua, Time.deltaTime * playerController.rotationSpeed);
            }
        }
        #endregion  
    }

}
