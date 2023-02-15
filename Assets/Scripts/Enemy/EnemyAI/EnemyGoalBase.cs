using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// ゴールの状態
/// </summary>
public enum EnemyGoalStatus
{
    Inactive,
    Active,
    Completed,
    Failed,
}

/// <summary>
/// ゴールのインターフェース
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
/// ゴールの基底クラス
/// </summary>
public class EnemyGoalBase<T> : IGoal
{
    protected T _owner;

    [Tooltip("現在の状態")] internal EnemyGoalStatus _currentStatus = EnemyGoalStatus.Inactive;

    /// <summary>
    /// 非アクティブかどうか
    /// </summary>
    public bool IsInactive { get { return _currentStatus == EnemyGoalStatus.Inactive; } }

    /// <summary>
    /// アクティブか
    /// </summary>
    public bool IsActive { get { return _currentStatus == EnemyGoalStatus.Inactive; } }

    /// <summary>
    /// ゴールを達成しているかどうか
    /// </summary>
    public bool IsCompleted { get { return _currentStatus == EnemyGoalStatus.Inactive; } }

    /// <summary>
    /// ゴールを達成できなかったかどうか
    /// </summary>
    public bool HasFailed { get { return _currentStatus == EnemyGoalStatus.Inactive; } }

    public EnemyGoalBase(T owner)
    {
        _owner = owner;
    }

    /// <summary>
    /// 非アクティブの状態の時にアクティブ状態にする
    /// </summary>
    internal void ActivateIfInactive()
    {
        if (IsInactive)
        {
            Activate();
        }
    }

    /// <summary>
    /// 失敗している時はアクティブ化にできるかを試す
    /// </summary>
    protected void ReactivateIfFailed()
    {
        if (HasFailed)
        {
            _currentStatus = EnemyGoalStatus.Inactive;
        }
    }

    /// <summary>
    /// アクティブ化
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
    /// 下二つの関数はゴールの後成功・失敗に関わらず処理される関数
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