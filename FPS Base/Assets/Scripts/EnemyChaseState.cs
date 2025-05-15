using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : IEnemyState
{
    private Enemy _enemy; // Ref to the Enemy script on this enemy
    public LayerMask playerLayer;
    public float _detectionRadius = 15f;

    public EnemyChaseState(Enemy enemy)
    {
        _enemy = enemy;
        playerLayer = LayerMask.GetMask("Player");
        _detectionRadius = _enemy.enemyData.detectionRadius;
    }

    public void Enter()
    {
         Debug.Log("Enemy is Chasing");
    }

    public void Update()
    {
        if(PlayerInSight())
        {
            _enemy.agent.SetDestination(_enemy.target.position);
        }
        else 
        {
            _enemy.SetState(new EnemyIdleState(_enemy));
        }
        
    }

    public void Exit()
    {
        Debug.Log("Exit Idle state");
    }

    private bool PlayerInSight()
    {
        // Perform an overlap sphere check at the enemy's position
        Collider[] hits = Physics.OverlapSphere(_enemy.transform.position, _detectionRadius, playerLayer);

        // Iterate through all colliders found
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                // Player detected within the radius
                return true;
            }
        }

        // No player detected within the radius
        return false;
    }


}
