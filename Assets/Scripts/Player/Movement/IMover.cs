namespace N_RPG.N_Player.N_Movement
{
	/// <summary>
	///   Mover interface.
	/// </summary>
	public interface IMover
	{
		#region Public fields

		/// <summary>
		///   Type of mover.
		/// </summary>
		MoverType MoverType { get; }

		#endregion

		#region Public methods

		/// <summary>
		///   Tick.
		/// </summary>
		void Tick();

		#endregion
	}
}