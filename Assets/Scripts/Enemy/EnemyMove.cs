using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

/// <summary>
/// �G�̓����𐧌䂷��R���|�[�l���g
/// </summary>
public class EnemyMove : MonoBehaviour
{
    [Header("�ړ�")]
    //[SerializeField, Tooltip("�v���C���[�̈ʒu")] Transform _playerPos;
    [SerializeField, Tooltip("�ړI�n")] Transform[] _wayPoints;
    [SerializeField, Tooltip("�ړ����x")] float _moveSpeed;
    [SerializeField, Tooltip("���͂����n������")] float _lookTime;
    [Tooltip("���݂̖ړI�n")] int _currentWayPointIndex;

    [Header("�Q�Ɨp")]
    [SerializeField, Tooltip("EnemyDetection�R���|�[�l���g")] EnemyDetection _enemyDetection;

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