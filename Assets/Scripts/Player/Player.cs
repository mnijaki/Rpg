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
	///   Mover.
	/// </summary>
	private IMover _mover;
	
	// MN:TO_DO: Change to IRotator
	/// <summary>
	///   Rotator.
	/// </summary>
	private Rotator _rotator;

	#endregion

	#region Protected and private methods

	/// <summary>
	///   Awake.
	/// </summary>
	private void Awake()
	{
		_mover = new Mover(this);
		_rotator = new Rotator(this);
	}

	/// <summary>
	///   Update.
	/// </summary>
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			_mover = new Mover(this);
		}
		else
		{
			if(Input.GetKeyDown(KeyCode.Alpha2))
			{
				_mover = new NavMeshMover(this);
			}
		}
		
		_mover.Tick();
		_rotator.Tick();
	}

	#endregion
}