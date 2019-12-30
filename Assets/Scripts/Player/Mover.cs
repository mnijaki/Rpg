using UnityEngine;
using UnityEngine.AI;

/// <summary>
///   Mover of player.
/// </summary>
public class Mover : IMover
{
	#region Public fields
	
	/// <summary>
	///   Type of mover.
	/// </summary>
	public MoverType MoverType { get; }
	
	#endregion
	
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
	/// <param name="moverType">Type of mover</param>
	public Mover(Player player, MoverType moverType)
	{
		_player = player;
		MoverType = moverType;
		_characterController = player.GetComponent<CharacterController>();
		
		_player.GetComponent<NavMeshAgent>().enabled = false;
	}

	/// <summary>
	///   Tick (called once per update frame).
	/// </summary>
	public void Tick()
	{
		Vector3 movementInput = new Vector3(_player.PlayerInput.Horizontal, 0.0F, _player.PlayerInput.Vertical);
		Vector3 movement = _player.transform.rotation * movementInput * MoverType.Sensitivity;
		_characterController.SimpleMove(movement);
	}
	
	#endregion
}