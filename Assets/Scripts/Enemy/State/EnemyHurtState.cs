using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtState : EnemyStateBase
{
    public override void Enter()
    {
        base.Enter();
        enemyController.PlayerAnimation("Damage", 0f);
    }

    public override void Update()
    {
        base.Update();

        #region ��⶯���Ƿ����

        if (IsAnimationEnd())
        {
            enemyController.SwitchState(EnemyState.Idle);
            return;
        }

        #endregion
    }
}
