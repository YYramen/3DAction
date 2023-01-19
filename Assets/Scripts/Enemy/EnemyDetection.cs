using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [Header("探知範囲")]
    [SerializeField, Tooltip("探知範囲(片側の角度)")] float _detectZone;
    [SerializeField, Tooltip("探知範囲のコライダー")] SphereCollider _detectCollider;
    [Tooltip("敵を見つけたかどうか")] bool _isDetected;
    [Tooltip("見つけたオブジェクトの位置")] Vector3 _detectedObjectPos;

    public bool IsDetected { get => _isDetected;}
    public Vector3 DetectedObjectPos { get => _detectedObjectPos; set => _detectedObjectPos = value; }

    private void OnDrawGizmos()
    {
        Handles.color = Color.green;
        Handles.DrawWireArc(transform.position, Vector3.up, Quaternion.Euler(0f, -_detectZone, 0f) * transform.forward, _detectZone * 2f, _detectCollider.radius);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var positionDiff = other.transform.position - transform.position;  // 自身（敵）とプレイヤーの距離
            var angle = Vector3.Angle(transform.forward, positionDiff);  // 敵から見たプレイヤーの方向
            if (angle <= _detectZone)
            {
                Debug.Log($"{this.name} が {other.name} を発見した");
                transform.LookAt(other.transform.position);
                _detectedObjectPos = other.transform.position;
                _isDetected = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"{other} が {this.name} の視界から外れた");
        _isDetected = false;
    }
}
