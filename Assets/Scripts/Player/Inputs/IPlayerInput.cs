using System;

namespace N_RPG.N_Player.N_Inputs
{
	/// <summary>
	///   Interface for player input.
	/// </summary>
	public interface IPlayerInput
	{
		#region Events

		/// <summary>
		///   Event - fired after movement mode key was pressed. 
		/// </summary>
		event Action MovementModeKeyPressed;

		/// <summary>
		///   Event - fired after Alpha key was pressed.
		///   <para></para>
		///   int - index of pressed Alpha key (0 - Alpha1, 1 - Alpha2, 2 - Alpha3...)
		/// </summary>
		event Action<int> AlphaKeyPressed;

		#endregion

		#region Public fields

		/// <summary>
		///   Vertical input.
		/// </summary>
		float Vertical { get; }

		/// <summary>
		///   Horizontal input.
		/// </summary>
		float Horizontal { get; }

		/// <summary>
		///   Mouse X input.
		/// </summary>
		float MouseX { get; }

		#endregion

		#region Public methods

		/// <summary>
		///   Tick.
		/// </summary>
		void Tick();

		#endregion
	}
}