using UnityEngine;

public class AIController
{
    [SerializeField] private Fsm _fsmMovement;
    [SerializeField] private Fsm _fsmAttack;

    public AIController(Fsm fsmMovement, Fsm fsmAttack)
    {
        _fsmMovement = fsmMovement;
        _fsmAttack = fsmAttack;
    }

    public void Update()
    {

    }
}
