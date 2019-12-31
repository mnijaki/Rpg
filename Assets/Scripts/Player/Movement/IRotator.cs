namespace N_RPG.N_Player.N_Movement
{
	/// <summary>
	///   Rotator interface.
	/// </summary>
	public interface IRotator
	{
		#region Public fields

		/// <summary>
		///   Type of rotator.
		/// </summary>
		RotatorType RotatorType { get; }

		#endregion

		#region Public methods

		/// <summary>
		///   Tick.
		/// </summary>
		void Tick();

		#endregion
	}
}