using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerIdleState
{

    public override void Enter()
    {
        base.Enter();
        playerController.PlayerAnimation("Run");
    }

    public override void Update()
    {
        base.Update();

        #region ��⹥��
        #endregion

        #region ������
        #endregion
    }

}
