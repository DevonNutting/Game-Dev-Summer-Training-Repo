using UnityEngine;

public class EnemyStateMachine
{
    // This clas is meant to be constructed by each enemy when they enter the scene for their own individual use
    public IEnemyState CurrentState {get; private set;}
    private Enemy _enemy;

    public EnemyStateMachine(Enemy enemy) // Constructor
    {
        this._enemy = enemy;
        SetState(new EnemyIdleState(enemy)); // Default state
    }

    public void SetState(IEnemyState newState)
    {
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
