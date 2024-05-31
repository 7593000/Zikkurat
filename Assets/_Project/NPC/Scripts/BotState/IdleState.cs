using UnityEngine;
/// <summary>
/// Состояние бота: Ожидание
/// </summary>
public class IdleState : IBotState
{
   // private readonly int _idleTimer = 5; // Таймер ожидания в секундах
  //  private int _currentTimer = 0;




    public void Enter(BotComponent bot)
    {
        bot.GetMoveStatus = false;
        bot.GetBotState = BotState.IDLE;
        Debug.Log("Переход в состояние: " + BotState.IDLE);
        bot.GetAnimator.SetFloat("Movement", 0);
 
    }

    // Метод для выполнения логики в текущем состоянии
    public void Execute(BotComponent bot)
    {

       
       
        //if (_currentTimer == _idleTimer)
        //{
        
        //    _currentTimer = 0;
        //}
        //_currentTimer++;
        //Debug.Log(_currentTimer);
    }

   
    public void Exit(BotComponent bot)
    {
        
        Debug.Log("Выход из состояние: " + BotState.IDLE);
    }

    public float GetWeight(BotComponent bot)
    {
        float weight = 0;
        bot.GetController.Idle = (int)weight;
        return 1;
    }
}
