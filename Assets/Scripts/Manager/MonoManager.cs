using System;

/// <summary>
/// Update trusteeship
/// </summary>
public class MonoManager : SingleMonoBase<MonoManager>
{
    /// <summary>
    /// update task gather
    /// </summary>
    private Action updateAction;

    /// <summary>
    /// fixed update task gather
    /// </summary>
    private Action fixedUpdateAction;

    /// <summary>
    /// late update task gather
    /// </summary>
    private Action lateUpdateAction;

    /// <summary>
    /// Add update action task
    /// </summary>
    /// <param name="task"></param>
    public void AddUpdateTask(Action updateTask)
    {
        updateAction += updateTask;
    }

    /// <summary>
    /// Remove update action task
    /// </summary>
    /// <param name="task"></param>
    public void RemoveUpdateTask(Action updateTask)
    {
        updateAction-= updateTask;
    }

    /// <summary>
    /// Add fixed update action task
    /// </summary>
    /// <param name="fixedTask"></param>
    public void AddFixedUpdate(Action fixedTask)
    {
        fixedUpdateAction += fixedTask;
    }

    /// <summary>
    /// Remove fixed update action task
    /// </summary>
    /// <param name="fixedTask"></param>
    public void RemoveFixedUpdate(Action fixedTask)
    {
        fixedUpdateAction -= fixedTask;
    }

    /// <summary>
    /// Add fixed update action task
    /// </summary>
    /// <param name="fixedTask"></param>
    public void AddLateUpdate(Action lateTask)
    {
        lateUpdateAction += lateTask;
    }

    /// <summary>
    /// Remove fixed update action task
    /// </summary>
    /// <param name="fixedTask"></param>
    public void RemoveLateUpdate(Action lateTask)
    {
        lateUpdateAction -= lateTask;
    }

    private void Update()
    {
        updateAction?.Invoke();
    }

    private void FixedUpdate()
    {
        fixedUpdateAction?.Invoke();
    }
    private void LateUpdate()
    {
        lateUpdateAction?.Invoke();
    }
}
