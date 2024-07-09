using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : SingleMonoBase<Test>
{
    private void Start()
    {
        MonoManager.Instance.AddUpdateTask(Task);
        MonoManager.Instance.AddFixedUpdate(FixedTask);
        MonoManager.Instance.AddLateUpdate(LateTask);

        StateBase stateBase = new PlayerIdleState();
    }

    private void Task()
    {
        Debug.Log("Task");
    }
    private void FixedTask()
    {
        Debug.Log("FixedTask");
    }
    private void LateTask()
    {
        Debug.Log("LateTask");
    }
}



