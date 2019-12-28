using UnityEngine;

public class Rotator
{
	#region Protected and private fields
	
	/// <summary>
	///  Player.
	/// </summary>
	private readonly Player _player;
	
	/// <summary>
	///   Rotation sensitivity.
	/// </summary>
	private const float _ROTATION_SENSITIVITY = 2.0F;
	
	#endregion
	
	#region Public mentods
	
	/// <summary>
	///   Constructor.
	/// </summary>
	/// <param name="player">Player to rotate</param>
	public Rotator(Player player)
	{
		_player = player;
	}
	
	/// <summary>
	///   Tick.
	/// </summary>
	public void Tick()
	{
		Vector3 rotation = new Vector3(0.0F, _player.PlayerInput.MouseX * _ROTATION_SENSITIVITY, 0.0F) ;
		_player.transform.Rotate(rotation);
	}
	
	#endregion
}