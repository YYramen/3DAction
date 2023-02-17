using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewEnemyTask : MonoBehaviour
{
    enum TaskType
    {
        WalkAround,
        Attack,
        Defence,
    }
    
    NewEnemyTaskList<TaskType> _taskList = new();



    Action _enter;
    Action _exit;

    private void Start()
    {
        _taskList.DefineTask(TaskType.WalkAround, _enter, _exit);
        _taskList.DefineTask(TaskType.Attack, _enter, _exit);
        _taskList.DefineTask(TaskType.Defence, _enter, _exit);

        _taskList.AddTask(TaskType.WalkAround);
        _taskList.AddTask(TaskType.Attack);
        _taskList.AddTask(TaskType.Defence);
    }

    private void Update()
    {
        //_taskList.UpdateTask();
        Debug.Log($"{_taskList.CurrentTaskTypeList.ToArray()}");
    }
}
