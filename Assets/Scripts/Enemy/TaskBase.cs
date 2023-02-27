using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �S�[���̏��
/// </summary>
public enum Status
{
    Inactive,
    Active,
    Completed,
    Failed,
}

/// <summary>
/// �^�X�N�C���^�[�t�F�[�X
/// </summary>
public interface ITask
{
    bool IsInactive { get; }
    bool IsActive { get; }
    bool IsCompleted { get; }
    bool HasFailed { get; }

    void Activate();
    Status Process();
    void Terminate();
    void AddSubgoal(ITask subgoal);
}

/// <summary>
/// �^�X�N�̊��N���X
/// </summary>
/// <typeparam name="T"></typeparam>
public class Task<T> : ITask where T : EnemyAIBase
{
    protected T _owner;

    /// <summary>
    /// ��A�N�e�B�u��
    /// </summary>
    public bool IsInactive { get { return _status == Status.Inactive; } }

    /// <summary>
    /// �A�N�e�B�u��
    /// </summary>
    public bool IsActive { get { return _status == Status.Active; } }

    /// <summary>
    /// �����ς�
    /// </summary>
    public bool IsCompleted { get { return _status == Status.Completed; } }

    /// <summary>
    /// �^�X�N���s��
    /// </summary>
    public bool HasFailed { get { return _status == Status.Failed; } }

    /// <summary>
    /// ���݂̃X�e�[�^�X
    /// </summary>
    internal Status _status = Status.Inactive;

    public Task(T owner)
    {
        _owner = owner;
    }


    /// <summary>
    /// ��A�N�e�B�u�Ȃ�A�N�e�B�u��ԂɈڍs����
    /// </summary>
    internal void ActivateIfInactive()
    {
        if (IsInactive)
        {
            Activate();
        }
    }

    /// <summary>
    /// ���s���Ă���ꍇ�̓A�N�e�B�u�������݂�
    /// </summary>
    protected void ReactivateIfFailed()
    {
        if (HasFailed)
        {
            _status = Status.Inactive;
        }
    }

    /// <summary>
    /// �A�N�e�B�x�C�g����
    /// </summary>
    public virtual void Activate()
    {
        Debug.Log("Start " + this);

        _status = Status.Active;
    }

    public virtual Status Process()
    {
        ActivateIfInactive();
        return _status;
    }

    /// <summary>
    /// �S�[���̌㏈��
    /// �����^���s�Ɋւ�炸���s�����
    /// </summary>
    public virtual void Terminate()
    {
        // do nothing.
    }

    public virtual void AddSubgoal(ITask subgoal)
    {
        // do nothing.
    }
}

/// <summary>
/// �T�u�S�[�������S�[��
/// </summary>
public class CompositeTask<T> : Task<T> where T : EnemyAIBase
{
    /// <summary>
    /// �T�u�S�[���̃��X�g
    /// </summary>
    protected List<ITask> _subgoals = new List<ITask>();

    // �R���X�g���N�^
    public CompositeTask(T owner) : base(owner) { }

    #region Override
    public override void Activate()
    {
        base.Activate();
    }

    public override Status Process()
    {
        ActivateIfInactive();
        return ProcessSubgoals();
    }

    public override void Terminate()
    {
        base.Terminate();
    }
    #endregion


    /// <summary>
    /// �T�u�S�[����ǉ�
    /// </summary>
    /// <param name="subgoal"></param>
    public override void AddSubgoal(ITask subgoal)
    {
        if (_subgoals.Contains(subgoal))
        {
            return;
        }

        _subgoals.Add(subgoal);
    }

    /// <summary>
    /// ���ׂẴT�u�S�[�����I�������A�N���A����
    /// </summary>
    protected void RemoveAllSubgoals()
    {
        foreach (var goal in _subgoals)
        {
            goal.Terminate();
        }

        _subgoals.Clear();
    }

    /// <summary>
    /// �T�u�S�[����]������
    /// </summary>
    /// <returns></returns>
    internal virtual Status ProcessSubgoals()
    {
        // �T�u�S�[�����X�g�̒��Ŋ��� or ���s�̃S�[�������ׂďI�������A���X�g����폜����
        while (_subgoals.Count > 0 &&
              (_subgoals[0].IsCompleted || _subgoals[0].HasFailed))
        {
            _subgoals[0].Terminate();
            _subgoals.RemoveAt(0);
        }

        // �T�u�S�[�����Ȃ��Ȃ����犮���B
        if (_subgoals.Count == 0)
        {
            _status = Status.Completed;
            return _status;
        }

        var firstGoal = _subgoals[0];

        // �c���Ă���T�u�S�[���̍őP�̃S�[����]������
        var subgoalStatus = firstGoal.Process();

        // �őO�̃S�[�����������Ă��āA���܂��T�u�S�[�����c���Ă���ꍇ�͏������p������
        if ((subgoalStatus == Status.Completed) &&
            _subgoals.Count > 1)
        {
            _status = Status.Active;
            return _status;
        }

        return _status;
    }
}
