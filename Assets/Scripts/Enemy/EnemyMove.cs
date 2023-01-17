using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [Header("移動系")]
    [SerializeField, Tooltip("移動速度")] float _moveSpeed = 1f;

    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void MoveToPlayer(Collider target)
    {
        if (target.CompareTag("Player"))
        {
            _rb.AddForce(target.transform.position * _moveSpeed, ForceMode.Impulse);
            if(((this.transform.position - target.transform.position).magnitude) == 0)
            {
                return;
            }

        }
    }
}