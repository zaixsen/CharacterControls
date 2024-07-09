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

        playerController.PlayerAnimation("Run");
    }

    public override void Update()
    {
        base.Update();

        #region ��⹥��
        #endregion

        #region ������
        if (playerController.inputMoveVec2 == Vector2.zero)
        {
            playerController.SwitchState(PlayerState.Idle);
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
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, targetQua, Time.deltaTime * playerController.rotationSpeed);
        }
        #endregion  
    }

}
