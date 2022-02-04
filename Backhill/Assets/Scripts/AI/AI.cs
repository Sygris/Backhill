using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum States { Attack, Search, Patrol, Wait };

public class AI : Patrol
{
    States _currentState;

    States GetCurrentState() { return _currentState; }
    void UpdateState(States targetState) { _currentState = targetState; }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _currentState = States.Patrol;
        NextNode();
    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentState)
        {
            case States.Attack:
                break;
            case States.Search:
                break;
            case States.Patrol:
                ContinuePatrol();
                break;
            case States.Wait:
                break;
            default:
                break;
        }
    }
}
