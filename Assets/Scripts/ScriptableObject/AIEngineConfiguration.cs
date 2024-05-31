 
using UnityEngine;
[CreateAssetMenu(fileName = "NewAIEngineConfiguration", menuName = "Configuration/AI Engine Configuration", order =52)]
public class AIEngineConfiguration : ScriptableObject
{
   
    //TODO => DEL 







        [SerializeField, Tooltip("��������� ������� ����")]
        private float _reviewBot = 30f;
 
        [SerializeField, Space, Tooltip("���������� ������ ����� ��� ���������")]
        private float _rangeWander = 10f;
        [SerializeField, Tooltip("����� �������� ������� ���������")]
        private float _wanderStatusDuration = 7f;



        /// <summary>
        /// ���������� ��������� ������� ����
        /// </summary>
        public float GetDistanceActivation => _reviewBot;
        /// <summary>
        /// ���������� ������ ����� ��� ���������
        /// </summary>
        public float GetRangeWander => _rangeWander;
        /// <summary>
        /// ����� �������� ������� ���������
        /// </summary>
        public float GetWanderStatusDuration => _wanderStatusDuration;
 

        
    }
 