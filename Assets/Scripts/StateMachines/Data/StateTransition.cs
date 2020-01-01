using System;

namespace N_RPG.N_StateMachines.N_Data
{
	/// <summary>
	///   State transition.
	/// </summary>
	public class StateTransition
	{
		#region Public fields

		/// <summary>
		///   Old state (state that we are transitioning from).
		/// </summary>
		public readonly IState OldState;
		
		/// <summary>
		///   New state (state that we are transitioning to).
		/// </summary>
		public readonly IState NewState;
		
		/// <summary>
		///   Condition that must be met to transition from old state to new state.
		/// </summary>
		public readonly Func<bool> Condition;
		
		#endregion
		
		#region Public methods
		
		/// <summary>
		///   Constructor.
		/// </summary>
		/// <param name="oldState">Old state (state that we are transitioning from)</param>
		/// <param name="newState">New state (state that we are transitioning to)</param>
		/// <param name="condition">Condition that must be met to transition from old state to new state</param>
		public StateTransition(IState oldState, IState newState, Func<bool> condition)
		{
			OldState = oldState;
			NewState = newState;
			Condition = condition;
		}
		
		#endregion
	}
}