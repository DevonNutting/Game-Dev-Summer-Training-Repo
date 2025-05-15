using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;
    [SerializeField] 
    public Transform target;

    public NavMeshAgent agent {get; private set;}

    private EnemyStateMachine stateMachine;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        stateMachine = new EnemyStateMachine(this);
    }

    private void Update()
    {
        stateMachine?.CurrentState?.Update(); // Call the Update() method of the current state of this enemy if there is one
    }

    public void SetState(IEnemyState newState)
    {
        stateMachine.SetState(newState);
    }

    public void TakeDamage()
    {
        // Implement in seperate Health script
    }

    // Optional: Visualize the detection radius in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyData.detectionRadius);
    }
}
