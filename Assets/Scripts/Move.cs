using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class Move : MonoBehaviour
{
    [SerializeField] private Vector3[] pointsDestination = null;
    [SerializeField] private EnemyData _enemyData = null;
    private NavMeshAgent _navMeshAgent = null;
    private int counterPoints = 0;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = _enemyData.Speed;
    }

    private void Update()
    {
        _navMeshAgent.SetDestination(pointsDestination[counterPoints]);
        float distance = Vector3.Distance(transform.position, pointsDestination[counterPoints]);

        if (distance <= 0.1f && counterPoints < pointsDestination.Length)
        {
            counterPoints++;
        }

    }

}
