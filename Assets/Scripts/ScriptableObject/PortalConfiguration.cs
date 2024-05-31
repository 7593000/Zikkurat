using UnityEngine;

[CreateAssetMenu(fileName = "NewPortalConfig", menuName = "Configuration/Create PortalConfig", order = 53)]

public class PortalConfiguration : ScriptableObject
{
    [Header("������ ���������� ������")]
    [SerializeField] private float _summoningTimer = 5f;

    [Header("�������������� � �������")]
    [SerializeField] private ColorFraction _colorPortal;

    [Header("�������� �������")]
    [SerializeField] private Material _materialPortal;





    //==============================================================================
    public float SummonTimer { get => _summoningTimer; }
    ///�������� ���� �������
    /// </summary>
    public ColorFraction ColorPortal { get => _colorPortal; }

    public Material MaterialFraction { get => _materialPortal; }




}
