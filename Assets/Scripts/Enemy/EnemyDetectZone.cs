using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class EnemyDetectZone : MonoBehaviour
{
    [SerializeField] private TriggerEvent _onTriggerStay = new TriggerEvent();

    /// <summary>
    /// Is Trigger��ON�ő���Collider�Əd�Ȃ��Ă���Ƃ��ɌĂ΂ꑱ����
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        // Inspector�^�u��onTriggerStay�Ŏw�肳�ꂽ���������s����
        _onTriggerStay.Invoke(other);
    }

    // UnityEvent���p�������N���X��[Serializable]������t�^���邱�ƂŁAInspector�E�C���h�E��ɕ\���ł���悤�ɂȂ�B
    [Serializable]
    public class TriggerEvent : UnityEvent<Collider>
    {
    }
}