using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : EnemyStateBase
{
    public override void Enter()
    {
        base.Enter();
        enemyController.PlayerAnimation("Death");
    }

}
