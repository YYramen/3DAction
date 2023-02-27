using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AI�̊��N���X
///
/// �e��p�����[�^�ȂǁAUI���f�ɕK�v�ȏ����W�񂷂�B
/// ��{�I�ɁA�N���X���S�[�������s���A
/// �N���X���S�[�����v�����j���O���邱�Ƃ�AI����������B
/// </summary>
public class EnemyAIBase : MonoBehaviour
{
    
    private Brain<AIBase> _brain;

    [SerializeField]
    private Transform[] _wanderTargets;
    public Transform[] WanderTargets { get { return _wanderTargets; } }

    // ���݂̗̑�
    [SerializeField]
    [Range(0f, 1f)]
    private float _health = 0.5f;
    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            if (value < 0)
            {
                value = 0;
            }
            _health = value;
        }
    }

    // �X�^�~�i
    [SerializeField]
    [Range(0f, 1f)]
    private float _energy = 0.5f;
    public float Energy
    {
        get
        {
            return _energy;
        }
        set
        {
            if (value < 0)
            {
                value = 0;
            }
            _energy = value;
        }
    }

    /// <summary>
    /// �Ώۂ��v�����I�u�W�F�N�g��ێ����Ă��邩������
    /// </summary>
    /// <param name="target">���ؑΏ�</param>
    /// <param name="planObject">�擾�����v�����I�u�W�F�N�g�̎Q�Ƃ�Ԃ�</param>
    /// <returns>�ێ����Ă���ꍇ��ture</returns>
    protected virtual bool HasPlan(GameObject target, out PlanObject planObject)
    {
        planObject = target.GetComponent<PlanObject>();
        return planObject != null;
    }

    /// <summary>
    /// �v�����I�u�W�F�N�g��ێ�����i�L������j
    /// </summary>
    /// <param name="planObject"></param>
    void StorePlanObject(PlanObject planObject)
    {
        _brain.Memorize(planObject);
    }
}