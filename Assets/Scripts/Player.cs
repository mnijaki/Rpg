using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerInput = new PlayerInput();
    }

    private void Update()
    {
        Vector3 movementInput = new Vector3(0.0F, 0.0F, _playerInput.Vertical);
        Vector3 movement = transform.rotation * movementInput;
        _characterController.SimpleMove(movement);
    }
}

public class PlayerInput
{
    public float Vertical
    {
        get { return Input.GetAxis("Vertical"); }
    }
}
