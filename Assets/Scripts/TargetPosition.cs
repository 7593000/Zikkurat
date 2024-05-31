using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/// <summary>
/// Точка для цели ботам при старте
/// </summary>
public class TargetPosition : MonoBehaviour
{
#if UNITY_EDITOR
    void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
       
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
#endif
}
