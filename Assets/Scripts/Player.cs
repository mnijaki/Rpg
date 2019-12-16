using UnityEngine;

public class Player : MonoBehaviour
{
	#region Public fields

	/// <summary>
	///   Player input.
	/// </summary>
	public IPlayerInput PlayerInput { get; set; } = new PlayerInput();

	#endregion
	
	#region Protected and private fields

	/// <summary>
	///   Character controller.
	/// </summary>
	private CharacterController _characterController;

	#endregion

	#region Protected and private methods

	/// <summary>
	///   Awake.
	/// </summary>
	private void Awake()
	{
		_characterController = GetComponent<CharacterController>();
	}

	/// <summary>
	///   Update.
	/// </summary>
	private void Update()
	{
		Vector3 movementInput = new Vector3(PlayerInput.Horizontal, 0.0F, PlayerInput.Vertical);
		Vector3 movement = transform.rotation * movementInput;
		_characterController.SimpleMove(movement);
	}

	#endregion
}