using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// �G�̃^�X�N(�ڕW)���Ǘ�����N���X
/// </summary>
public class NewEnemyTaskList<T> where T : Enum
{
    private class Task
    {
        public T TaskType;
        public Action Enter { get; set; }
        public Func<bool> Update { get; set; }
        public Action Exit { get; set; }

        public Task(T t, Action enter, Func<bool> update, Action exit)
        {
            TaskType = t;
            Enter = enter;
            Update = update ?? delegate { return true; };
            Exit = exit;
        }
    }

    /// <summary> ��`���ꂽ�^�X�N </summary>
    Dictionary<T, Task> _defineTaskDictionary = new Dictionary<T, Task>();
    /// <summary> ���ݐς܂�Ă���^�X�N </summary>
    List<Task> _currentTaskList = new List<Task>();
    /// <summary> ���ݓ��삵�Ă���^�X�N </summary>
    Task _currentTask = null;
    /// <summary> ���݂�Index�ԍ� </summary>
    int _currentIndex = 0;

    /// <summary>
    /// �ǉ����ꂽ�^�X�N�����ׂďI�����Ă��邩
    /// </summary>
    public bool IsEnd
    {
        get { return _currentTaskList.Count <= _currentIndex; }
    }

    /// <summary>
    ///  �^�X�N�������Ă��邩
    /// </summary>
    public bool IsMoveTask
    {
        get { return _currentTask != null; }
    }

    /// <summary>
    /// ���݂̃^�X�N�^�C�v
    /// </summary>
    public T CurrentTaskType
    {
        get
        {
            if (_currentTask == null)
                return default(T);
            return _currentTask.TaskType;
        }
    }

    /// <summary>
    /// �ǉ�����Ă���^�X�N�̃��X�g
    /// </summary>
    public List<T> CurrentTaskTypeList
    {
        get
        {
            return _currentTaskList.Select(x => x.TaskType).ToList();
        }
    }

    /// <summary>
    /// ���݂̃C���f�b�N�X
    /// </summary>
    public int CurrentIndex
    {
        get { return _currentIndex; }
    }

    /// <summary>
    /// ���t���[���Ă΂�鏈��
    /// (Behaviour��Update�ŌĂ΂��z��)
    /// </summary>
    public void UpdateTask()
    {
        // �^�X�N���Ȃ���Ή������Ȃ�
        if (IsEnd)
        {
            return;
        }

        // ���݂̃^�X�N���Ȃ���΁A�^�X�N���擾����
        if (_currentTask == null)
        {
            _currentTask = _currentTaskList[_currentIndex];
            // Enter���Ă�
            _currentTask.Enter?.Invoke();
        }

        // �^�X�N��Update���Ă�
        var isEndOneTask = _currentTask.Update();

        // �^�X�N���I�����Ă���Ύ��̏������Ă�
        if (isEndOneTask)
        {
            // ���݂̃^�X�N��Exit���Ă�
            _currentTask?.Exit();

            // Index�ǉ�
            _currentIndex++;

            // �^�X�N���Ȃ���΃N���A����
            if (IsEnd)
            {
                _currentIndex = 0;
                _currentTask = null;
                _currentTaskList.Clear();
                return;
            }

            // ���̃^�X�N���擾����
            _currentTask = _currentTaskList[_currentIndex];
            // ���̃^�X�N��Enter���Ă�
            _currentTask?.Enter();
        }
    }

    /// <summary>
    /// �^�X�N�̒�`
    /// </summary>
    /// <param name="t"></param>
    /// <param name="enter"></param>
    /// <param name="update"></param>
    /// <param name="exit"></param>
    public void DefineTask(T t, Action enter, Func<bool> update, Action exit)
    {
        var task = new Task(t, enter, update, exit);
        var exist = _defineTaskDictionary.ContainsKey(t);
        if (exist)
        {
#if UNITY_EDITOR
            Debug.LogError($"{GetType()}�͊��ɒǉ�����Ă��܂��B(�o�^����܂���ł���).");
#endif
            return;
        }
        _defineTaskDictionary.Add(t, task);
    }

    public void DefineTask(T t, Action enter, Action exit)
    {
        DefineTask(t, enter, () => true, exit);
    }

    /// <summary>
    /// �^�X�N�̓o�^
    /// </summary>
    /// <param name="t"></param>
    public void AddTask(T t)
    {
        Task task = null;
        var exist = _defineTaskDictionary.TryGetValue(t, out task);
        if (exist == false)
        {
#if UNITY_EDITOR
            Debug.LogError($"{GetType()}�̃^�X�N���o�^����Ă��Ȃ��̂Œǉ��ł��܂���.");
#endif
            return;
        }
        _currentTaskList.Add(task);
    }

    /// <summary>
    /// �����I��
    /// </summary>
    public void ForceStop()
    {
        if (_currentTask != null)
        {
            _currentTask.Exit();
        }
        _currentTask = null;
        _currentTaskList.Clear();
        _currentIndex = 0;
    }
}
