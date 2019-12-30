using UnityEngine;

/// <summary>
///   Rotator of player.
/// </summary>
public class Rotator : IRotator
{
	#region Public fields
	
	/// <summary>
	///   Type of rotator.
	/// </summary>
	public RotatorType RotatorType { get; }
	
	#endregion
	
	#region Protected and private fields
	
	/// <summary>
	///  Player.
	/// </summary>
	private readonly Player _player;
	
	#endregion
	
	#region Public mentods

	/// <summary>
	///   Constructor.
	/// </summary>
	/// <param name="player">Player to rotate</param>
	/// <param name="rotatorType">Type of rotator</param>
	public Rotator(Player player, RotatorType rotatorType)
	{
		_player = player;
		RotatorType = rotatorType;
	}
	
	/// <summary>
	///   Tick (called once per update frame).
	/// </summary>
	public void Tick()
	{
		Vector3 rotation = new Vector3(0.0F, _player.PlayerInput.MouseX * RotatorType.Sensitivity, 0.0F) ;
		_player.transform.Rotate(rotation);
	}
	
	#endregion
}