using System.Collections;
 
using UnityEngine;
using UnityEngine.InputSystem;


 
[RequireComponent(typeof(Rigidbody))]
public sealed class MovementController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    PlayerControl _control;
    private bool isMouseDeltaActive = false;

    [SerializeField]
    private float _speedCameraMoving = 10f;

    [SerializeField,Range(0f,1f)]
    private float _sensitivity = 1.0f;

    private Coroutine _movingCoroutine;
 
    
    private void OnEnable()
    {
        _control.Enable();
        _control.Human.Moving.performed +=   Moving;
        _control.Human.Moving.canceled += _ =>StopMoving();  
        _control.Human.HoldMouseButton.performed +=_=> ActivatorMouseDelta(true);
        _control.Human.HoldMouseButton.canceled +=_ => ActivatorMouseDelta(false);
    }

    private void OnDisable()
    {
        _control.Disable();
       
    }

    private void  ActivatorMouseDelta(bool isActive)
    {
        if (isActive != isMouseDeltaActive)
        {
            isMouseDeltaActive = isActive;
         
            if (isActive)
            {
                _control.Human.MouseDelta.performed += callbackContext => Mouse—ontrolOfCamera(callbackContext);
            }
            else
            {
                _control.Human.MouseDelta.performed -= callbackContext => Mouse—ontrolOfCamera(callbackContext);
            }
        }
    }
    
    private void Mouse—ontrolOfCamera(InputAction.CallbackContext   callbackContext)
    {

        if(isMouseDeltaActive == false) { return; }

        float lookAngle = 90f;
        Vector2 lookingInputDelta = callbackContext.ReadValue<Vector2>();
        Vector3 lookRotation = new Vector3(-lookingInputDelta.y, lookingInputDelta.x ) * _sensitivity;
        Quaternion deltaRotation = Quaternion.Euler(lookRotation);
        transform.rotation *= deltaRotation;
        float currentXRotation = transform.eulerAngles.x;
        currentXRotation = (currentXRotation > 180f) ? currentXRotation - 360f : currentXRotation; // œÂÓ·‡ÁÓ‚‡ÌËÂ Û„Î‡ ‚ ‰Ë‡Ô‡ÁÓÌ -180, 180
        float clampedXRotation = Mathf.Clamp(currentXRotation, -lookAngle, lookAngle);
        transform.rotation = Quaternion.Euler(clampedXRotation, transform.eulerAngles.y, 0f);


    }
  

    private void Moving(InputAction.CallbackContext context)
        {
        var  moveVectot = context.ReadValue<Vector3>();
        
        if (_movingCoroutine != null) StopCoroutine(_movingCoroutine);
        _movingCoroutine = StartCoroutine(MovingCoroutine(moveVectot));
        }

    private IEnumerator MovingCoroutine(Vector3 move)
    {
        while (true)
        {

            Vector3 normalizedMove = move.normalized;
            Vector3 rotatedMove = transform.TransformDirection(normalizedMove);
            _rigidbody.velocity = rotatedMove * _speedCameraMoving;

            yield return null;
        }
    }

  


    private void StopMoving()
    {

        StopCoroutine(_movingCoroutine);
    }

     

     

    private void Awake()
    {
        _control = new PlayerControl();
        _rigidbody = GetComponent<Rigidbody>();
    }
}
