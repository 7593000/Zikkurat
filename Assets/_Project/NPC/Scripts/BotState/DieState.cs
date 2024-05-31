using UnityEngine;

internal class DieState : IBotState
{
    
    public void Enter( BotComponent bot )
    {
        Debug.Log("Переход в состояние: " + BotState.DIE);
        
        bot.GetHealthComponent.TakeDamage(-1);
        bot.GetMoveStatus = false;
        bot.GetTargetEnemy = null;
        bot.GetStatusAidkit = false;
        bot.GetAnimator.SetTrigger("Dead");
        bot.GetComponent<Rigidbody>().useGravity = false;
        bot.GetComponent<CapsuleCollider>().enabled = false;
        bot.IsDie = true;
        bot.ShowSpriteAnimation(SpriteType.GHOST);

    }

    public void Execute( BotComponent bot )
    {
         
    }

    public void Exit( BotComponent bot )
    {
        Debug.Log("Из " + BotState.DIE + "ВЫХОДА НЕТ!!!");
          
       
    }


    public float GetWeight(BotComponent bot)
    {
        if(!bot.gameObject.activeSelf) return 0f;
       
        float weight = 0f;
      
        if ( !bot.Activity )
        {
            

            weight = 10000;
        }

        bot.GetController.Dead = (int)weight;
     
        return weight;
    }


     

}