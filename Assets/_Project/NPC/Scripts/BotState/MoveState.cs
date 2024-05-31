using UnityEngine;
/// <summary>
/// �������� ���� � ����� 
/// </summary>
public class MoveState : IBotState
{


    public void Enter(BotComponent bot)
    {
        Debug.Log("������� � ���������: " + BotState.MOVE);
       bot.GetBotState = BotState.MOVE;
    }

    public void Execute(BotComponent bot)
    {
        Debug.Log( BotState.MOVE);

    }



    public void Exit(BotComponent bot)
    {
        Debug.Log("����� �� ���������: " + BotState.MOVE);
        
       
    }
    public float GetWeight(BotComponent bot)
    {

        float weight = 0;
        bot.GetController.Move = (int)weight;
        return  0;
    }

}