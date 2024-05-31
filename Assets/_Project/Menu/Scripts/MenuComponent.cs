using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MenuComponent : MonoBehaviour
{
    public static event Action OnDeadAll;
    public static event Action OnClearStat;

    private PortalComponent _portal;
    private RectTransform _menuRectTransform;
    [SerializeField] private float _speedActionMenu = 5f;
    private bool _isOpenMenu = false;
    private bool _isWorkMenu = false;
    private bool _isVisibleHPBar = true;
    [SerializeField] private RectTransform _sidebarRectTransform;
    [SerializeField] private RectTransform _settingsRect;
    [SerializeField] private SettingsComponent _settingsMenu;
    [SerializeField] private StatisticsComponent _statisticsMenu;

    [Space]
    [Header("Настройки иконки портала")]
    [SerializeField] private Color _bluePortal;
    [SerializeField] private Color _greenPortal;
    [SerializeField] private Color _redPortal;
    [SerializeField] private Image _icoPortal;



    public void LoadConfiguration(PortalComponent portal, BotStatsConfig config)
    {
        _portal = portal;
        _isWorkMenu = true;
        _icoPortal.color = (_icoPortal != null) ? SelectColorIco(_portal.ColorPortal) : Color.white;
        _statisticsMenu.LoadStatistics(_portal);
        _settingsMenu.LoadSettings(config);
        if (!_isOpenMenu) BMenuAction();

    }



    /// <summary>
    /// Отобразить - спрятать HP у ботов
    /// </summary>
    public void BHealthBarVisible()
    {
        _isVisibleHPBar = !_isVisibleHPBar;
        HealthBarComponent.SetHealthBarsVisibility(_isVisibleHPBar);


    }

    /// <summary>
    /// Очистить статистику по смертям
    /// </summary>
    public void BClearResult()
    {

        OnClearStat?.Invoke();
        Debug.Log("Clear");
    }

    /// <summary>
    /// Убить всех активных юнитов
    /// </summary>
    public void BKillAllUnits()
    {
        OnDeadAll?.Invoke();

    }
    /// <summary>
    /// показать-спрятать меню
    /// </summary>
    public void BMenuAction()
    {
        if (!_isWorkMenu) return;

        float newPosition;
        float widthSettings = _settingsRect.rect.width;

        if (_isOpenMenu)
        {

            newPosition = _menuRectTransform.anchoredPosition.x + widthSettings;
            _isOpenMenu = false;
        }
        else
        {
            newPosition = _menuRectTransform.anchoredPosition.x - widthSettings;
            _isOpenMenu = true;
        }
        StartCoroutine(MoveWindowMenu(newPosition));

    }


    /// <summary>
    /// Перемещение меню 
    /// </summary>
    IEnumerator MoveWindowMenu(float position)
    {
        Vector2 startPos = _menuRectTransform.anchoredPosition;

        Vector2 endPos = new Vector2(position, _menuRectTransform.anchoredPosition.y); // Измените по необходимости

        float elapsedTime = 0f;

        while (elapsedTime < _speedActionMenu)
        {
            _menuRectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, elapsedTime / _speedActionMenu);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _menuRectTransform.anchoredPosition = endPos;
    }


    private Color SelectColorIco(ColorFraction color)
    {
        var colorPortal = color switch
        {
            ColorFraction.RED => _redPortal,
            ColorFraction.GREEN => _greenPortal,
            ColorFraction.BLUE => _bluePortal,
            _ => Color.red,
        };

        return colorPortal;
    }



    private void Awake()
    {

        _menuRectTransform ??= GetComponent<RectTransform>();

        Vector2 currentPosition = _menuRectTransform.anchoredPosition;

        Vector2 newPosition = new(currentPosition.x + _settingsRect.rect.width, currentPosition.y);

        _menuRectTransform.anchoredPosition = newPosition;
    }

}
