using N_RPG.N_Player.N_Inputs;
using N_RPG.N_Player.N_Movement;
using UnityEngine;

namespace N_RPG.N_Player
{
	public class Player : MonoBehaviour
	{
		#region Public fields

		/// <summary>
		///   Player input.
		/// </summary>
		public IPlayerInput PlayerInput { get; set; } = new PlayerInput();

		/// <summary>
		///   Mover.
		/// </summary>
		public IMover Mover { get; private set; }

		/// <summary>
		///   Rotator.
		/// </summary>
		public IRotator Rotator { get; private set; }

		#endregion

		#region Serialized fields

		/// <summary>
		///   Type of mover.
		/// </summary>
		[SerializeField]
		[Tooltip("Type of mover")]
		private MoverType _moverType;

		/// <summary>
		///   Type of rotator.
		/// </summary>
		[SerializeField]
		[Tooltip("Type of rotator")]
		private RotatorType _rotatorType;

		#endregion

		#region Protected and private methods

		/// <summary>
		///   Awake.
		/// </summary>
		private void Awake()
		{
			Mover = new Mover(this, _moverType);
			Rotator = new Rotator(this, _rotatorType);
		}

		/// <summary>
		///   On enable.
		/// </summary>
		private void OnEnable()
		{
			PlayerInput.MovementModeKeyPressed += PlayerInputOnMovementModeKeyPressed;
		}

		/// <summary>
		///   On disable.
		/// </summary>
		private void OnDisable()
		{
			PlayerInput.MovementModeKeyPressed -= PlayerInputOnMovementModeKeyPressed;
		}

		/// <summary>
		///   Update.
		/// </summary>
		private void Update()
		{
			PlayerInput.Tick();
			Mover.Tick();
			Rotator.Tick();
		}

		#endregion

		#region Events handlers

		/// <summary>
		///   Event - fired after movement mode key was pressed.
		/// </summary>
		private void PlayerInputOnMovementModeKeyPressed()
		{
			if(Mover is Mover)
			{
				Mover = new NavMeshMover(this, _moverType);
			}
			else
			{
				Mover = new Mover(this, _moverType);
			}
		}

		#endregion
	}
}