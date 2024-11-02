using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [Header("References")]
    public Transform _playerTransform;
    
    [Header("FlipRotationStats")]
    public float _flipYRotationTime = 0.5f;
    private Coroutine _turnCoroutine;
    private PlayerMovement _player;
    public bool _isFacingRight;
    private void Awake()
    {
        _player = _playerTransform.gameObject.GetComponent<PlayerMovement>();
        _isFacingRight = _player.facingRight;
    }
    private void Update()
    {

        transform.position = _playerTransform.position;
        
    }

    public void CallTurn()
    {
        _turnCoroutine = StartCoroutine(FlipYLerp());
    }

    private IEnumerator FlipYLerp()
    {
        float startRotation = transform.localEulerAngles.y;
        float endRotationAmount = DetermineEndRotation();
        float yRotation = 0f;
        
        float elapsedTime = 0f;
        while(elapsedTime < _flipYRotationTime)
        {
            elapsedTime += Time.deltaTime;

            yRotation = Mathf.Lerp(startRotation, endRotationAmount, (elapsedTime/ _flipYRotationTime));
            transform.rotation = Quaternion.Euler(0f, yRotation, 0f);

            yield return null;
        }
    }

    private float DetermineEndRotation()
    {
        
        _isFacingRight = _player.facingRight;
        if(_isFacingRight)
        {
            return 0f;
        }else
        {
            return 180f;;
        }
    }
}
