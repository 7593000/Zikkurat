using UnityEngine;
/// <summary>
/// ��������� ����: ��������
/// </summary>
public class IdleState : IBotState
{
   // private readonly int _idleTimer = 5; // ������ �������� � ��������
  //  private int _currentTimer = 0;




    public void Enter(BotComponent bot)
    {
        bot.GetMoveStatus = false;
        bot.GetBotState = BotState.IDLE;
        Debug.Log("������� � ���������: " + BotState.IDLE);
        bot.GetAnimator.SetFloat("Movement", 0);
 
    }

    // ����� ��� ���������� ������ � ������� ���������
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
        
        Debug.Log("����� �� ���������: " + BotState.IDLE);
    }

    public float GetWeight(BotComponent bot)
    {
        float weight = 0;
        bot.GetController.Idle = (int)weight;
        return 1;
    }
}
