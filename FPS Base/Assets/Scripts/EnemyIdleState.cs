using UnityEngine;

public class EnemyIdleState : IEnemyState
{
    private Enemy _enemy;
    public LayerMask playerLayer;
    public float _detectionRadius = 15f;

    public EnemyIdleState(Enemy enemy) // Constructor
    {   
        _enemy = enemy;
        playerLayer = LayerMask.GetMask("Player");
    }

    public void Enter()
    {
        Debug.Log("Enemy is Idling");
        _detectionRadius = _enemy.enemyData.detectionRadius;
    }

    public void Update()
    {
        if (PlayerInSight()) _enemy.SetState(new EnemyChaseState(_enemy)); // Use the Enemy script to exit this state and enter the new one 
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
