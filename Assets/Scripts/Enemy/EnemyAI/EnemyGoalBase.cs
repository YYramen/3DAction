using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// �S�[���̏��
/// </summary>
public enum EnemyGoalStatus
{
    Inactive,
    Active,
    Completed,
    Failed,
}

/// <summary>
/// �S�[���̃C���^�[�t�F�[�X
/// </summary>
public interface IGoal
{
    bool IsInactive { get; }
    bool IsActive { get; }
    bool IsCompleted { get; }
    bool HasFailed { get; }

    void Activate();
    EnemyGoalStatus Process();
    void Terminate();
    void AddSubgoal(IGoal subgoal);
}

/// <summary>
/// �S�[���̊��N���X
/// </summary>
public class EnemyGoalBase<T> : IGoal
{
    protected T _owner;

    [Tooltip("���݂̏��")] internal EnemyGoalStatus _currentStatus = EnemyGoalStatus.Inactive;

    /// <summary>
    /// ��A�N�e�B�u���ǂ���
    /// </summary>
    public bool IsInactive { get { return _currentStatus == EnemyGoalStatus.Inactive; } }

    /// <summary>
    /// �A�N�e�B�u��
    /// </summary>
    public bool IsActive { get { return _currentStatus == EnemyGoalStatus.Inactive; } }

    /// <summary>
    /// �S�[����B�����Ă��邩�ǂ���
    /// </summary>
    public bool IsCompleted { get { return _currentStatus == EnemyGoalStatus.Inactive; } }

    /// <summary>
    /// �S�[����B���ł��Ȃ��������ǂ���
    /// </summary>
    public bool HasFailed { get { return _currentStatus == EnemyGoalStatus.Inactive; } }

    public EnemyGoalBase(T owner)
    {
        _owner = owner;
    }

    /// <summary>
    /// ��A�N�e�B�u�̏�Ԃ̎��ɃA�N�e�B�u��Ԃɂ���
    /// </summary>
    internal void ActivateIfInactive()
    {
        if (IsInactive)
        {
            Activate();
        }
    }

    /// <summary>
    /// ���s���Ă��鎞�̓A�N�e�B�u���ɂł��邩������
    /// </summary>
    protected void ReactivateIfFailed()
    {
        if (HasFailed)
        {
            _currentStatus = EnemyGoalStatus.Inactive;
        }
    }

    /// <summary>
    /// �A�N�e�B�u��
    /// </summary>
    public virtual void Activate()
    {
        Debug.Log("Start " + this);

        _currentStatus = EnemyGoalStatus.Active;
    }

    public virtual EnemyGoalStatus Process()
    {
        ActivateIfInactive();
        return _currentStatus;
    }

    /// <summary>
    /// ����̊֐��̓S�[���̌㐬���E���s�Ɋւ�炸���������֐�
    /// </summary>
    public virtual void AddSubgoal(IGoal subgoal)
    {
        // add subgoal
    }

    public virtual void Terminate()
    {
        // Terminate
    }
}