using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlanner : EnemyPlannerBase 
{
    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    public EnemyPlanner(EnemyPlannerBase owner): base(owner) { }

    public override float EvaluatePlan(EnemyPlanBase plan)
    {
        float value = 0;

        //if(plan)
        // TODO : EnemyPlanBase�N���X����낤

        return value;
    }
}
