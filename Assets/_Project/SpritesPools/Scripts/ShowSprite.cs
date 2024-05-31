using System.Collections;
using UnityEngine;

public class ShowSprite : MonoBehaviour
{
    private Camera _mainCamera;
    private Coroutine _coroutine;
    private GameObject _sprite;
    private SpriteType _type;
    public void Move(SpriteType type, float duration, float upDistance)
    {

       

        if (_coroutine != null)
        {
            PoolSprites.Instance.Deactivate(_type, _sprite);
          
            _type = type;
            _sprite = PoolSprites.Instance.GetSptire(_type);
           
            StopCoroutine(_coroutine);
            _coroutine = null;

            _coroutine = StartCoroutine(SpriteCoroutine(_sprite, _type, duration, upDistance));
        }
        else
        {
            _type = type;
            _sprite = PoolSprites.Instance.GetSptire(_type);
           
            _coroutine = StartCoroutine(SpriteCoroutine(_sprite, _type, duration, upDistance));

        }


    }



    private IEnumerator SpriteCoroutine(GameObject sprite, SpriteType type, float duration, float upDistance)
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + new Vector3(0, upDistance, 0);
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            if (_mainCamera != null)
            {

                sprite.transform.LookAt(sprite.transform.position + _mainCamera.transform.rotation * Vector3.forward,
                                 _mainCamera.transform.rotation * Vector3.up);
            }

            sprite.transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        sprite.transform.position = endPos;

        PoolSprites.Instance.Deactivate(type, sprite); // Возвращаем спрайт в пул
    }



    private void Start()
    {
        _mainCamera = Camera.main;

    }


}
