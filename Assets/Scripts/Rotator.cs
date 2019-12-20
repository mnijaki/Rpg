using UnityEngine;

public class Rotator
{
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
	public Rotator(Player player)
	{
		_player = player;
	}
	
	/// <summary>
	///   Tick.
	/// </summary>
	public void Tick()
	{
		Vector3 rotation = new Vector3(0.0F, _player.PlayerInput.MouseX, 0.0F);
		_player.transform.Rotate(rotation);
	}
	
	#endregion
}