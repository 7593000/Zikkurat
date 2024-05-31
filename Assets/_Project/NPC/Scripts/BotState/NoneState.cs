 
using UnityEngine;

public class NoneState : IBotState
{
    public void Enter(BotComponent bot)
    {
        Debug.Log("������� � ���������: " + BotState.NONE);
    }

    public void Execute(BotComponent bot)
    {
        
    }
 

    public void Exit(BotComponent bot)
    {
        Debug.Log("����� �� ���������: " + BotState.NONE);
    }
    public float GetWeight(BotComponent bot)
    {
        float weight = 0;
        bot.GetController.None = (int)weight;
        return 0;
    }
}
