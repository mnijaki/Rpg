using UnityEngine;
using UnityEngine.AI;

/// <summary>
///   Mover of object.
/// </summary>
public class Mover : IMover
{
	#region Protected and private fields
	
	/// <summary>
	///  Player.
	/// </summary>
	private readonly Player _player;
	
	/// <summary>
	///   Character controller.
	/// </summary>
	private readonly CharacterController _characterController;
	
	#endregion

	#region Public mentods
	
	/// <summary>
	///   Constructor.
	/// </summary>
	/// <param name="player">Player to move</param>
	public Mover(Player player)
	{
		_player = player;
		_characterController = player.GetComponent<CharacterController>();
		
		_player.GetComponent<NavMeshAgent>().enabled = false;
	}

	/// <summary>
	///   Tick.
	/// </summary>
	public void Tick()
	{
		Vector3 movementInput = new Vector3(_player.PlayerInput.Horizontal, 0.0F, _player.PlayerInput.Vertical);
		Vector3 movement = _player.transform.rotation * movementInput;
		_characterController.SimpleMove(movement);
	}
	
	#endregion
}