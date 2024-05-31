using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AidKitManager : MonoBehaviour, IUpdateComponent
{
    
    [SerializeField]
    private List<AidKitComponent> _listAirKit = new();

    public int GetActiveAirKitCount()
    {
        return _listAirKit.Where(t => t.gameObject.activeSelf).Count();
    }

    /// <summary>
    /// Поиск ближайщей атпечки 
    /// </summary>
    /// <param name="bot"></param>
    /// <returns></returns>
    public AidKitComponent GetActiveAirKit(BotComponent bot)
    {
        float minDistance = float.MaxValue;
        AidKitComponent nearestAidKit = null;

        var currentPosition = bot.transform.position;

        foreach (AidKitComponent aidkit in _listAirKit)
        {
            if (aidkit.GetStatus)
            {
                float distance = (currentPosition - aidkit.transform.position).sqrMagnitude;

               
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestAidKit = aidkit;
                }
            }
        }
        return nearestAidKit;
    

        
       

    }
    /// <summary>
    /// Проверка аптечки на активность
    /// </summary>
    /// <param name="airkit"></param>
    /// <returns></returns>
    public bool CheckedActiveAirKit( AidKitComponent airkit)
    {
        if(_listAirKit.Contains(airkit))
        {
            return airkit.GetStatus; 
          //  return airkit.gameObject.activeSelf;
        }
        return false;
      
    }

    public void UpdateComponent()
    {
        for ( int i = 0; i < _listAirKit.Count; i++ )
        {
            _listAirKit[ i ].ChechStatus();

        }
    }

    private void Awake()
    {
        _listAirKit??= FindObjectsOfType<AidKitComponent>().ToList();

    }



}
