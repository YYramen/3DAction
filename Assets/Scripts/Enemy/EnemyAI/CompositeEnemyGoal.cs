using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �T�u�S�[���𑩂˂�e�S�[��
/// </summary>

public class CompositeEnemyGoal : EnemyGoalBase<IGoal>
{
    [Tooltip("�T�u�S�[���̃��X�g")] protected List<IGoal> _subgoalList = new List<IGoal>();

    protected new IGoal _owner;

    public CompositeEnemyGoal(IGoal owner) : base(owner)
    {
        _owner = owner;
    }

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>


    public override EnemyGoalStatus Process()
    {
        ActivateIfInactive();
        return ProcessSubgoal();
    }

    /// <summary>
    /// �T�u�S�[����ǉ�
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
    /// �S�ẴT�u�S�[�����I�������폜����
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
    /// �T�u�S�[����]�����Ă�������
    /// </summary>
    /// <returns></returns>
    internal virtual EnemyGoalStatus ProcessSubgoal()
    {
        // �T�u�S�[�����X�g�̒��Ŋ��� or ���s�̃S�[�������ׂďI�������A���X�g����폜����
        while (_subgoalList.Count > 0 &&
              (_subgoalList[0].IsCompleted || _subgoalList[0].HasFailed))
        {
            _subgoalList[0].Terminate();
            _subgoalList.RemoveAt(0);
        }

        // �T�u�S�[�����Ȃ��Ȃ����犮���B
        if (_subgoalList.Count == 0)
        {
            _currentStatus = EnemyGoalStatus.Completed;
            return _currentStatus;
        }

        var firstGoal = _subgoalList[0];

        // �c���Ă���T�u�S�[���̍őO�̃S�[����]������
        var subgoalStatus = firstGoal.Process();

        // �őO�̃S�[�����������Ă��āA���܂��T�u�S�[�����c���Ă���ꍇ�͏������p������
        if ((subgoalStatus == EnemyGoalStatus.Completed) &&
            _subgoalList.Count > 1)
        {
            _currentStatus = EnemyGoalStatus.Active;
            return _currentStatus;
        }

        return _currentStatus;
    }
}
