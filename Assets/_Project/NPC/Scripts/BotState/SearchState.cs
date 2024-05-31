using UnityEngine;
/// <summary>
/// Состояние бота: Поиск врага, движение к последней позиции врага
/// </summary>
public class SearchState : IBotState
{

    public void Enter(BotComponent bot)
    {
        bot.GetMoveStatus = true;
        Debug.Log("Переход в состояние: " + BotState.SEARCH);
       
    }

    public void Execute(BotComponent bot)
    {


        if (bot.GetTargetEnemy != null && bot.GetStatusPanicMode == false)
        {
            BotComponent enemy = bot.GetTargetEnemy;
            bot.GetTarget = enemy.transform.position;

        }



    }


    public void Exit(BotComponent bot)
    {
        Debug.Log("Выход из состояния: " + BotState.SEARCH);
        //bot.GetMoveStatus = false;
    }


    public float GetWeight(BotComponent bot)
    {
        if (bot.Activity == false) return 0f;
      
        float weight;
     
        float healthFactor = bot.GetHealthComponent.GetHealth / bot.GetConfig.Health;


        if (bot.GetTargetEnemy != null && !bot.GetStatusPanicMode && bot.GetTargetEnemy.Activity == true)
        {
            weight = 50;

            float distance = bot.CheckDisctance();

            weight += (bot.GetHealthComponent.GetHealth - bot.GetTargetEnemy.GetHealthComponent.GetHealth) * healthFactor;
           
            if (distance != float.NaN && distance > bot.GetConfig.ActiveDistance)
            {
                weight += bot.CheckDisctance();

                bot.GetMoveStatus = true;
            }
            else
            {
             
                weight -= 50;
            }

        }
        else
        {
            bot.GetTargetEnemy = null;
            weight = 0;
        }


        weight = Mathf.Clamp(weight, 0f, 100f);
        bot.GetController.Search = (int)weight;
        return weight;
     }
}
