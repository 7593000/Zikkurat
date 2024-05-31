using UnityEngine;
/// <summary>
/// Движение бота к точке 
/// </summary>
public class MoveState : IBotState
{


    public void Enter(BotComponent bot)
    {
        Debug.Log("Переход в состояние: " + BotState.MOVE);
       bot.GetBotState = BotState.MOVE;
    }

    public void Execute(BotComponent bot)
    {
        Debug.Log( BotState.MOVE);

    }



    public void Exit(BotComponent bot)
    {
        Debug.Log("Выход из состояние: " + BotState.MOVE);
        
       
    }
    public float GetWeight(BotComponent bot)
    {

        float weight = 0;
        bot.GetController.Move = (int)weight;
        return  0;
    }

}