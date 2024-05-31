
using UnityEngine;
using UnityEngine.EventSystems;

public class Portal : PortalComponent, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private SettingsComponent _menuSettings;
    [SerializeField] private MenuComponent _menu;

    public  void OnPointerClick(PointerEventData eventData)
    {
        if (this is PortalComponent)
        {
            
         //   _menuSettings.LoadSettings(_botStatsConfig);
            _menu.LoadConfiguration(this,_botStatsConfig);
            
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        if (this is PortalComponent portalComponent)
        {
            _materialPortal.EnableKeyword("_EMISSION");
            Cursor.SetCursor(_cursorTexture, _hotSpot, _cursorMode);
        }

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _materialPortal.DisableKeyword("_EMISSION");
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

    }


    protected override void Awake()
    {
       base.Awake();

    }
    protected override void Start()
    {
        base.Start();
        
    }
}
