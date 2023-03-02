using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 攻撃するタスク
/// </summary>
/// <typeparam name="T"></typeparam>
public class EnemyAttackTask<T> : Task<T> where T : EnemyAIBase
{
    private GameObject _targetObj;
    private Vector3 _targetPos;
    [SerializeField] private float _attackDistance;

    bool AbleToAttack
    {
        get
        {
            var distance = Vector3.Distance(_targetPos, _owner.transform.position);
            if (distance > _attackDistance)
            {
                return false;
            }

            if (_owner.Health < 0.1f)
            {
                return false;
            }

            return true;
        }
    }

    #region コンストラクタ

    public EnemyAttackTask(T owner, GameObject targetObj, Vector3 targetPos) : base(owner)
    {
        _targetObj = targetObj;
        _targetPos = targetPos;
    }

    #endregion

    /// <summary>
    /// アイテムを実際にピックアップ
    /// </summary>
    void Attack()
    {
        Debug.Log("ATTACK!!");

        _owner.Health -= 0.1f;
    }

    public override Status Process()
    {
        ActivateIfInactive();

        if (AbleToAttack)
        {
            Attack();
            _status = Status.Completed;
        }
        else
        {
            Debug.Log("Cannot attack target.");
            _status = Status.Failed;
        }

        return _status;
    }

    public override void Terminate()
    {
        Debug.Log("Terminated EnemyAttackTask.");
    }
}
