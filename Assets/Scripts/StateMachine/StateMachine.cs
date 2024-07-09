using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Onwer Interface
/// </summary>
public interface IStateMachineOwner { }

/// <summary>
/// finite state machine
/// </summary>
public class StateMachine
{
    /// <summary>
    /// Current state 
    /// </summary>
    private StateBase currentState;

    /// <summary>
    /// Owner
    /// </summary>
    private IStateMachineOwner stateMachineOwner;

    /// <summary>
    /// Is has state
    /// </summary>
    public bool HasState { get => currentState != null; }

    private Dictionary<Type, StateBase> dic_states;

    public StateMachine(IStateMachineOwner owner)
    {
        dic_states = new Dictionary<Type, StateBase>();
        Init(owner);
    }

    /// <summary>
    /// Init Owner
    /// </summary>
    /// <param name="owner"></param>
    public void Init(IStateMachineOwner owner)
    {
        stateMachineOwner = owner;
    }

    /// <summary>
    /// Enter State
    /// </summary>
    /// <typeparam name="T">Only State machine model </typeparam>
    public void EnterState<T>() where T : StateBase, new()
    {
        //same state return

        if (HasState && currentState.GetType() == typeof(T)) return;

        #region Exit pre state

        if (HasState)
            EixtCurrentState();
        #endregion

        #region Enter new State

        currentState = LoadState<T>();
        EnterCurrentState();

        #endregion
    }

    /// <summary>
    /// Load state  if not has  create it
    /// </summary>
    /// <typeparam name="T">state type</typeparam>
    /// <returns></returns>
    public StateBase LoadState<T>() where T : StateBase, new()
    {
        Type stateType = typeof(T);
        //if dictionary not has new state . Create it
        if (!dic_states.TryGetValue(stateType, out StateBase state))
        {
            state = new T();
            state.Init(stateMachineOwner);
            dic_states.Add(stateType, state);
        }
        return state;
    }

    private void EnterCurrentState()
    {
        currentState.Enter();
        MonoManager.Instance.AddUpdateTask(currentState.Update);
        MonoManager.Instance.AddLateUpdate(currentState.LateUpdate);
        MonoManager.Instance.AddFixedUpdate(currentState.FixedUpdate);
    }

    private void EixtCurrentState()
    {
        currentState.Exit();
        MonoManager.Instance.RemoveUpdateTask(currentState.Update);
        MonoManager.Instance.RemoveLateUpdate(currentState.LateUpdate);
        MonoManager.Instance.RemoveFixedUpdate(currentState.FixedUpdate);
    }

    /// <summary>
    /// Stop state , release resources
    /// </summary>
    public void Stop()
    {
        EixtCurrentState();
        foreach (StateBase state in dic_states.Values)
        {
            state.UnInit();
        }
        dic_states.Clear();
    }
}
