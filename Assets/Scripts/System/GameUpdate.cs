using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameUpdate : MonoBehaviour
{

    [SerializeField]
    private bool _isUpdate = true;
    [SerializeField]
    private float _timeUpdate = 0.5f;

    

    [SerializeField]
    private List<IUpdateComponent> _components = new();
 

    private void Start()
    {
        _components = FindObjectsOfType<MonoBehaviour>().OfType<IUpdateComponent>().ToList();
        StartCoroutine( UpdateComponents() );
    }

  



    private IEnumerator UpdateComponents()
    {
        while ( _isUpdate )
        {
            foreach ( IUpdateComponent component in _components )
            {
                component.UpdateComponent();
            }

            yield return new WaitForSeconds( _timeUpdate );
        }
    }
}
