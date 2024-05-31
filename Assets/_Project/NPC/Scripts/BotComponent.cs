using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public abstract class BotComponent : MonoBehaviour
{
    private IBotState _currentState;
    [SerializeField]
    private ColorFraction _colorBot;

    [SerializeField]
    protected BotStatsConfig _config;
    [SerializeField] private ShowSprite _sprite;
    [Space]
    [Header("________________________________________________________________________________________________")]
    [Space]
    [SerializeField] protected string _detectedTrigger;
    [SerializeField] protected TargetPosition _targetPosition;
    [SerializeField] private BotController _controller;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected HealthComponent _healthComponent;
    [SerializeField] protected AidKitManager _healthManager;
 
    [SerializeField] private float _upDistance = 5f;
    [SerializeField] private float _duration = 2f;
    [SerializeField] private Renderer _objBody;
    [SerializeField] private Renderer _objShield;



    public void Container(BotStatsConfig config)
    {
        _config = config;
    }

    /// <summary>
    /// �������� ����, � �������� �� ��� ���
    /// </summary>
    public bool GetMoveStatus = false;

    public ColorFraction GetColorBot { get => _colorBot; set { _colorBot = value; } }
    /// <summary>
    /// �������-�� ���
    /// </summary>
    public bool Activity { get; set; } = false;
    public bool IsDie { get; set; } = false;
    /// <summary>
    /// ��� �����������
    /// </summary
    public BotState GetBotState { get; set; }
    /// <summary>
    /// ��������� ��������� ����
    /// </summary>
    public BotComponent GetTargetEnemy = null;
    public HealthComponent GetHealthComponent => _healthComponent;
    public AidKitManager GetHealthManager => _healthManager;
    /// <summary>
    /// ���� �� ��������� �������
    /// </summary>
    public bool GetStatusAidkit;
    public bool GetStatusPanicMode { get; set; } = false;
    /// <summary>
    /// �������� ����� ��� ���������� �� ��������� ( ����� � ������ ���� ) 
    /// </summary>
    public TargetPosition GetTargetDefault => _targetPosition;
    public Vector3 GetTarget;
    public Animator GetAnimator => _animator; //�������� ��������� Animator

    public BotStatsConfig GetConfig => _config;

    public BotController GetController => _controller;

    public void InstallColor(Material material)
    {

        _objBody.material = material;
        _objShield.material = material;
    }

    /// <summary>
    /// �������� ��������� �� �����
    /// </summary>
    public float CheckDisctance()
    {
        if (GetTargetEnemy != null)
        {

            float distance = Vector3.Distance(transform.position, GetTargetEnemy.transform.position);

            return distance;
        }
        return float.NaN;


    }

    public void ShowSpriteAnimation(SpriteType type)
    {

       
        _sprite.Move(type, _duration, _upDistance);

      
    }
    


    /// <summary>
    /// ����� ��� ��������� ��������� ����
    /// </summary> 
    public void ChangeBotState(IBotState newState)
    {
        if (newState != _currentState)
        {

            _currentState?.Exit(this);
            _currentState = newState;
            _currentState?.Enter(this);

        }

    }






    /// <summary>
    /// ���������� �������� ����
    /// </summary>
    public void UpdateBot()
    {
        if (gameObject.activeSelf)
        {
            _currentState?.Execute(this);
        }
    }





    protected void Awake()
    {
        _targetPosition = FindFirstObjectByType<TargetPosition>();
        GetTarget = SetNewRandomTargetPosition();
        _healthManager = FindFirstObjectByType<AidKitManager>();
        _healthComponent = GetComponentInChildren<HealthComponent>();
        _sprite = GetComponentInChildren<ShowSprite>();


        GetTarget = _targetPosition.transform.position;
    }


    private void Start()
    {
        InstallComponents();

    }

    private void InstallComponents()
    {


        _healthComponent.Container(this);


    }


    /// <summary>
    /// ������� ��������� ����� ������������ ������� �� ����� ( ��� ������ ) 
    /// </summary>
    /// <returns></returns>
    private Vector3 SetNewRandomTargetPosition()
    {
        float xRandom = Random.Range(-10f, 10f);
        float zRandom = Random.Range(-10f, 10f);

        return new Vector3(
               _targetPosition.transform.position.x + xRandom,
               _targetPosition.transform.position.y,
               _targetPosition.transform.position.z + zRandom
           );
    }






}
