using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

/// <summary>
/// 敵の動きを制御するコンポーネント
/// </summary>
public class EnemyMove : MonoBehaviour
{
    [Header("移動")]
    //[SerializeField, Tooltip("プレイヤーの位置")] Transform _playerPos;
    [SerializeField, Tooltip("目的地")] Transform[] _wayPoints;
    [SerializeField, Tooltip("移動速度")] float _moveSpeed;
    [SerializeField, Tooltip("周囲を見渡す時間")] float _lookTime;
    [Tooltip("現在の目的地")] int _currentWayPointIndex;

    [Header("参照用")]
    [SerializeField, Tooltip("EnemyDetectionコンポーネント")] EnemyDetection _enemyDetection;

    NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(_wayPoints[0].position);
        _agent.speed = _moveSpeed;
    }

    private void Update()
    {
        LookAround();
    }

    private void LookAround()
    {
        if (_agent != null && _enemyDetection != null)
        {
            if (_enemyDetection.IsDetected == true)
            {
                MoveToPlayer();
            }
            else if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                _currentWayPointIndex = (_currentWayPointIndex + 1) % _wayPoints.Length;
                _agent.SetDestination(_wayPoints[_currentWayPointIndex].position);
            }
        }
    }

    private void MoveToPlayer()
    {
        _agent.SetDestination(_enemyDetection.DetectedObjectPos);
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            _agent.velocity = Vector3.zero;
        }
    }
}