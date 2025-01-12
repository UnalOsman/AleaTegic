using UnityEngine;

public interface IState
{
    void EnterState(Unit player);
    void UpdateState(Unit player);
    void ExitState(Unit player);
    
}
