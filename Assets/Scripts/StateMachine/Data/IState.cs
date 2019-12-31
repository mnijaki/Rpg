namespace RPG.StateMachines.Data
{
	/// <summary>
	///   Interface for state (building block for state machine).
	/// </summary>
	public interface IState
	{
		#region Public methods

		/// <summary>
		///   Tick.
		/// </summary>
		void Tick();

		/// <summary>
		///   On enter to the state.
		/// </summary>
		void OnEnter();

		/// <summary>
		///   On exit from the state.
		/// </summary>
		void OnExit();

		#endregion
	}
}

