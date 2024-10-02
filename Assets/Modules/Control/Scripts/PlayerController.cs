using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [Inject] private PlayerInput _inputCore;
    [Inject(Id = "PlayerTransfrom")]  private Transform _playerTransform;

    private InputActionAsset _actions;
    private InputAction _move;
    private Vector2 _direction;


    void Start()
    {
        if (_inputCore == null) Debug.Log("Все плохо");
        if (_playerTransform == null) Debug.Log("Все очень плохо");
        _actions = _inputCore.actions;
        _move = _actions.FindAction("Move");

        _move.performed += WhenMoving;
        _move.canceled += WhenStop;
    }

    private void WhenStop(InputAction.CallbackContext obj)
    {
        _direction = Vector2.zero;
    }

    private void WhenMoving(InputAction.CallbackContext obj)
    {
        _direction = obj.ReadValue<Vector2>();
    }

    private void ReplaceTransform(Vector2 direction)
    {
        Vector3 move = new Vector3(direction.x, direction.y, 0) * Time.deltaTime * 5f;
        _playerTransform.Translate(move, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        ReplaceTransform(_direction);
    }
}
