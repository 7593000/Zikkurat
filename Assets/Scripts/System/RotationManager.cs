using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
    [SerializeField]
    private float _speedRotation = 15f;
    private Vector3 _rotationSpeed;
    [SerializeField]
    private bool _isAnimating = true;
    [SerializeField]
    private List<Transform> _rotationList = new();
    private IEnumerator RotationAnimation()
    {
        while ( _isAnimating )
        {
            foreach ( Transform obj in _rotationList )
            {
                if ( obj != null )
                {
                   
                    obj.Rotate( -_rotationSpeed * Time.deltaTime );
                }
            }
            
            yield return null;
        }


    }

    private void Start()
    {
        _rotationSpeed = new Vector3( 0 , _speedRotation , 0 );
        StartCoroutine( RotationAnimation() );

    }
}
