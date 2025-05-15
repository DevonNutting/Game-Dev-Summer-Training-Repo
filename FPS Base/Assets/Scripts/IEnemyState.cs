using UnityEngine;

public interface IEnemyState
{
    /*
    Interfaces are like contracts. An interface defines what a class can do, but does not worry about how.
    Any script that derives from this interface MUST implement all of the functions in this interface.
    This creates consistency across all scripts that derive from this interface.
    */

    void Enter(); // The method called in a state when the state machine enters this state
    void Update(); // This is where most of the state's logic will be implemented in their own state script
    void Exit(); // This method is called when the state machine switches from the current state to the next
}
