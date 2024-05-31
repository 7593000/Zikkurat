using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

public class StatisticsComponent : MonoBehaviour
{
    [SerializeField] private TMP_Text _unitsCount;
    [SerializeField] private TMP_Text _deadUnits;
    [SerializeField] private TMP_Text _timer;

    private Coroutine _coroutine;
    private PortalComponent _portal;
    private int _counter = 0;

    private void OnEnable()
    {
        MenuComponent.OnClearStat += MakeAdjustment;
    }
    private void OnDisable()
    {
        MenuComponent.OnClearStat -= MakeAdjustment;

    }

    private void MakeAdjustment()
    {
        _counter = _portal.GetPortalBots.Where(t => t == t.IsDie).Count();
    }

    public void LoadStatistics(PortalComponent portal)
    {
        _portal = portal;

        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(ShowResult());
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
            _coroutine = StartCoroutine(ShowResult());
        }
    }

    private IEnumerator ShowResult()
    {


        while (true)
        {


            int units = _portal.GetPortalBots.Where(t => t == t.Activity).Count();
            int dead = _portal.GetPortalBots.Where(t => t == t.IsDie).Count();
            dead -= _counter;
          
            _unitsCount.text = units.ToString();
            _deadUnits.text = dead.ToString();
            _timer.text = _portal.GetTimeReport.ToString("F0");

            yield return new WaitForSeconds(1f);
        }

    }

}

