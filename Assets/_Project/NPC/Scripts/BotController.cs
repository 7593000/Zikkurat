using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{

#if UNITY_EDITOR

    public int Idle = 0;
    public int Patrol = 0;
    public int Escape = 0;
    public int Search = 0;
    public int SHealth = 0;
    public int Attack = 0;
    public int Move = 0;
    public int None = 0;
    public int Dead = 0;



#endif



    private BotComponent _bot;

    private IBotState _noneState;
    private IBotState _idleState;
    private IBotState _patrolState;
    private IBotState _moveState;
    private IBotState _searchState;
    private IBotState _attackingState;
    private IBotState _seekHealthState;
    private IBotState _escapeState;
    private IBotState _dieState;

    private List<IBotState> _state = new();
     
    private void Awake()
    {
        _bot = GetComponent<BotComponent>();
      
    }
    private void Start()
    {
        InstalState();
    }
    public void InstalState()
    {
        _noneState = new NoneState();
        _idleState = new IdleState();
        _patrolState = new PatrolState();
        _moveState = new MoveState();
        _searchState = new SearchState();
        _attackingState = new AttackingState( _bot );
        _seekHealthState = new SeekHealthState();
        _escapeState = new EscapeState();
        _dieState = new DieState();

        _state.Add(_noneState);
        _state.Add(_idleState);
        _state.Add(_patrolState);
        _state.Add(_moveState);
        _state.Add(_searchState);
        _state.Add(_attackingState);
        _state.Add(_seekHealthState);
        _state.Add(_escapeState);
        _state.Add(_dieState);

    }

    public void GetWeights()
    {
        float bestWeight = float.MinValue;
        IBotState bestAction = null;
           

        for (int i = 0; i < _state.Count; i++)
        {
          
            float weight = _state[i].GetWeight(_bot);

            if (weight > bestWeight)
            {
                bestWeight = weight;
                bestAction = _state[i];

            }
        }
          
        _bot.ChangeBotState(bestAction);
        
         
    }

    
     


}
