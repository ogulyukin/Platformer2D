using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrkVision : MonoBehaviour
{
    [SerializeField] private GameObject currentHitObject;
    [SerializeField] private float circleRadius;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;

    private Vector2 _origin;
    private Vector2 _direction = Vector2.right;
    public bool FindTarget{ get; private set; }

    private float _currentHitDistance;

    private void Update()
    {
        _origin = transform.position;
        RaycastHit2D hit = Physics2D.CircleCast(_origin, circleRadius, _direction, maxDistance, layerMask);

        _direction = GetComponent<OrcController>().GetDirection() ? Vector2.right : Vector2.left;

        if (hit)
        {
            currentHitObject = hit.transform.gameObject;
            _currentHitDistance = hit.distance;
            if(currentHitObject.CompareTag("Player"))
            {
                FindTarget = true;
            }
        }else
        {
            currentHitObject = null;
            _currentHitDistance = maxDistance;
            FindTarget = false;
        }
    }

    public float GetDistance()
    {
        return _currentHitDistance;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(_origin, _origin + _direction * _currentHitDistance);
        Gizmos. DrawSphere(_origin + _direction * _currentHitDistance, circleRadius);
    }
}
