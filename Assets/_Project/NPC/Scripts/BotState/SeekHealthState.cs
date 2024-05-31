using UnityEngine;
/// <summary>
/// Состояние бота: Поиск аптечки
/// </summary>
public class SeekHealthState : IBotState
{
    private AidKitComponent _airkit;
 





    public float GetWeight(BotComponent bot)
    {
        if (bot.Activity == false) return 0f;

        float weight = 0;

          
        if (bot.GetHealthComponent == null)
        {
            Debug.Log("GetHealthComponent is Null");

        }
        if (bot.GetHealthComponent.GetHealth == 0)
        {
            Debug.Log("bot.GetHealthComponent.GetHealth is Zero");
        }

        if (bot.GetStatusPanicMode)
        {
            weight -= bot.GetHealthComponent.GetHealthFactor();
        }
        else
        {
            weight += bot.GetHealthComponent.GetHealthFactor();

        }
      

        if (!bot.GetStatusAidkit)
        {
            weight -= 10;
        }
        else
        {
            weight += 10;
        }


        weight += bot.GetHealthComponent.GetHealthFactor();


        weight = Mathf.Clamp(weight, 0f, 100f);


        bot.GetController.SHealth = (int)weight;

        return weight;
    }


    public void Enter(BotComponent bot)
    {
        Debug.Log("Переход в состояние: " + BotState.SEEKHEALTH);
      

        bot.GetMoveStatus = true;
       
       
         _airkit = bot.GetHealthManager.GetActiveAirKit(bot);


        if (_airkit != null)
        {
            bot.GetStatusAidkit = true;
            bot.GetTarget = _airkit.transform.position;
            bot.GetTargetEnemy = null;
        }
        else
        {
            bot.GetStatusPanicMode = true;
            bot.GetStatusAidkit = false;
          

        }
          
    }



    public void Execute(BotComponent bot)
    {

        // bot.GetStatusAidkit = true;
        if (_airkit != null)
        {
            if (bot.GetHealthManager.CheckedActiveAirKit(_airkit) && bot.GetStatusPanicMode)
            {
                bot.GetTarget = _airkit.transform.position;
            }
            else
            {
                _airkit = bot.GetHealthManager.GetActiveAirKit(bot);
                bot.GetTarget = _airkit.transform.position;
                bot.GetMoveStatus = true;
            }
        }
            
        else
        {
            bot.GetStatusPanicMode = true;
            bot.GetStatusAidkit = false;
        }
         
           
            
 



    }

    public void Exit(BotComponent bot)
    {
       

        bot.GetStatusPanicMode = false;
        bot.GetStatusAidkit = false;
        Debug.Log("Выход из состояние: " + BotState.SEEKHEALTH);


    }






}
