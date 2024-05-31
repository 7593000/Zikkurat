using UnityEngine;

[CreateAssetMenu(fileName = "NewPortalConfig", menuName = "Configuration/Create PortalConfig", order = 53)]

public class PortalConfiguration : ScriptableObject
{
    [Header("Таймер призывания юнитов")]
    [SerializeField] private float _summoningTimer = 5f;

    [Header("Принадлежность к фракции")]
    [SerializeField] private ColorFraction _colorPortal;

    [Header("Материал фракции")]
    [SerializeField] private Material _materialPortal;





    //==============================================================================
    public float SummonTimer { get => _summoningTimer; }
    ///Передать цвет фракции
    /// </summary>
    public ColorFraction ColorPortal { get => _colorPortal; }

    public Material MaterialFraction { get => _materialPortal; }




}
