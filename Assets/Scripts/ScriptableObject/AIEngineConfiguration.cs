 
using UnityEngine;
[CreateAssetMenu(fileName = "NewAIEngineConfiguration", menuName = "Configuration/AI Engine Configuration", order =52)]
public class AIEngineConfiguration : ScriptableObject
{
   
    //TODO => DEL 







        [SerializeField, Tooltip("Дальность взгляда бота")]
        private float _reviewBot = 30f;
 
        [SerializeField, Space, Tooltip("Расстояние выбора точки при блуждании")]
        private float _rangeWander = 10f;
        [SerializeField, Tooltip("Время действия статуса блуждания")]
        private float _wanderStatusDuration = 7f;



        /// <summary>
        /// Возвращает дальность взгляда бота
        /// </summary>
        public float GetDistanceActivation => _reviewBot;
        /// <summary>
        /// Расстояние выбора точки при блуждании
        /// </summary>
        public float GetRangeWander => _rangeWander;
        /// <summary>
        /// Время действия статуса блуждания
        /// </summary>
        public float GetWanderStatusDuration => _wanderStatusDuration;
 

        
    }
 