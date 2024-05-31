using UnityEngine;

public class AidKitComponent : MonoBehaviour
{
    [SerializeField, Tooltip( "���������� ������������ ��������" )]
    private  float _sizeHealth = 40f;
    [SerializeField, Tooltip( "����� ����������� �������" )]
    private int _deactiveTime = 20;
 
    private Renderer _renderer;
    [SerializeField] private Texture _deavtiveTexture;
    [SerializeField] private Texture _activateTexture;

    public int TimerDeactive { get; set; }
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    /// <summary>
    /// ������ ������� ����������� ��� �������������� 
    /// </summary>
    public bool GetStatus { get; private set; } = true;
   
    private void OnTriggerEnter( Collider other )
    {


        if ( GetStatus && other.TryGetComponent<BotComponent>( out BotComponent bot ) )
        {
            Deactivation();
            bot.GetHealthComponent.Health( _sizeHealth );
            bot.GetStatusPanicMode = false;
             bot.GetMoveStatus = false;
         //   bot.GetTarget = bot.GetTargetDefault.transform.position;
        }


    }
    //���� ������� ��������. �� ����� ����� ������� ������� ������� �� ��������� �������. 
    public void ChechStatus()
    {
        
        if ( GetStatus )
        {
            return;
        }
        else if ( GetStatus == false )
        {
            TimerDeactive--;
            if ( TimerDeactive == 0 )
            {
                Activation();
            }
        }
    }
    /// <summary>
    /// ����������� �������
    /// </summary>
    private void Deactivation()
    {
        if ( _renderer != null && _deavtiveTexture != null )
        {
            _renderer.material.mainTexture = _deavtiveTexture;
        }
        TimerDeactive = _deactiveTime;
        GetStatus = false;

    }
    /// <summary>
    /// ��������� �������
    /// </summary>
    private void Activation()
    {
        GetStatus = true;
        TimerDeactive = 0;

        if ( _renderer != null && _activateTexture != null )
        {
            _renderer.material.mainTexture = _activateTexture;
        }


    }
}
