using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// State Base
/// </summary>
public abstract class StateBase
{
    /// <summary>
    /// Init State
    /// </summary>
    /// <param name="stateMachineOwner">Owner</param>
    public abstract void Init(IStateMachineOwner stateMachineOwner);

    /// <summary>
    /// Enter State
    /// </summary>
    public abstract void Enter();

    /// <summary>
    /// End State
    /// </summary>
    public abstract void Exit();

    /// <summary>
    /// against Init
    /// </summary>
    public abstract void UnInit();

    public abstract void Update();
    public abstract void FixedUpdate();
    public abstract void LateUpdate();
}
