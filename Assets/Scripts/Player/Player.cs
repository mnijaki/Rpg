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
	///   On enable.
	/// </summary>
	private void OnEnable()
	{
		PlayerInput.MovementModeKeyPressed += PlayerInputOnMovementModeKeyPressed;
	}

	/// <summary>
	///   Update.
	/// </summary>
	private void Update()
	{
		PlayerInput.Tick();
		_mover.Tick();
		_rotator.Tick();
	}

	#endregion
	
	#region Events handlers
	
	/// <summary>
	///   Event - fired after movement mode key was pressed.
	/// </summary>
	private void PlayerInputOnMovementModeKeyPressed()
	{
		if(_mover.GetType() == typeof(Mover))
		{
			_mover = new NavMeshMover(this);
		}
		else
		{
			_mover = new Mover(this);
		}
	}
	
	#endregion
}