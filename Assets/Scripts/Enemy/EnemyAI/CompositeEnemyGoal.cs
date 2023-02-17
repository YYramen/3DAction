using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// サブゴールを束ねる親ゴール
/// </summary>

public class CompositeEnemyGoal : EnemyGoalBase<IGoal>
{
    [Tooltip("サブゴールのリスト")] protected List<IGoal> _subgoalList = new List<IGoal>();

    protected new IGoal _owner;

    public CompositeEnemyGoal(IGoal owner) : base(owner)
    {
        _owner = owner;
    }

    /// <summary>
    /// コンストラクタ
    /// </summary>


    public override EnemyGoalStatus Process()
    {
        ActivateIfInactive();
        return ProcessSubgoal();
    }

    /// <summary>
    /// サブゴールを追加
    /// </summary>
    /// <param name="subgoal"></param>
    public override void AddSubgoal(IGoal subgoal)
    {
        if (_subgoalList.Contains(subgoal))
        {
            return;
        }

        _subgoalList.Add(subgoal);
    }

    /// <summary>
    /// 全てのサブゴールを終了させ削除する
    /// </summary>
    protected void RemoveAllSubgoals()
    {
        foreach(var goals in _subgoalList)
        {
            goals.Terminate();
        }

        _subgoalList.Clear();
    }


    /// <summary>
    /// サブゴールを評価していく処理
    /// </summary>
    /// <returns></returns>
    internal virtual EnemyGoalStatus ProcessSubgoal()
    {
        // サブゴールリストの中で完了 or 失敗のゴールをすべて終了させ、リストから削除する
        while (_subgoalList.Count > 0 &&
              (_subgoalList[0].IsCompleted || _subgoalList[0].HasFailed))
        {
            _subgoalList[0].Terminate();
            _subgoalList.RemoveAt(0);
        }

        // サブゴールがなくなったら完了。
        if (_subgoalList.Count == 0)
        {
            _currentStatus = EnemyGoalStatus.Completed;
            return _currentStatus;
        }

        var firstGoal = _subgoalList[0];

        // 残っているサブゴールの最前のゴールを評価する
        var subgoalStatus = firstGoal.Process();

        // 最前のゴールが完了していて、かつまだサブゴールが残っている場合は処理を継続する
        if ((subgoalStatus == EnemyGoalStatus.Completed) &&
            _subgoalList.Count > 1)
        {
            _currentStatus = EnemyGoalStatus.Active;
            return _currentStatus;
        }

        return _currentStatus;
    }
}
