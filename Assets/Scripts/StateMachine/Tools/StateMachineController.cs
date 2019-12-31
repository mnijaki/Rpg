using System.Collections.Generic;
using RPG.StateMachines.Data;
using UnityEngine;

namespace RPG.StateMachines.Tools
{
	/// <summary>
	///   State machine controller.
	/// </summary>
	public class StateMachineController
	{
		#region Protected and private fields

		/// <summary>
		///   Collection of all available states.
		/// </summary>
		private readonly List<IState> _states = new List<IState>();

		/// <summary>
		///   Current state.
		/// </summary>
		private IState _currentState;

		#endregion

		#region Public methods

		/// <summary>
		///   Add state to collection of available states.
		/// </summary>
		/// <param name="state">State to add to collection of available states</param>
		public void Add(IState state)
		{
			if(_states.Contains(state))
			{
				Debug.Log($"State machine already contains state [{state}]");
				return;
			}
			
			_states.Add(state);
		}

		/// <summary>
		///   Change state.
		/// </summary>
		/// <param name="newState">New state of state machine</param>
		public void ChangeState(IState newState)
		{
			if(_currentState == newState)
			{
				return;
			}

			_currentState?.OnExit();
			_currentState = newState;
			_currentState.OnEnter();

			Debug.Log($"Changed state to [{newState}]");
		}

		/// <summary>
		///   Tick.
		/// </summary>
		public void Tick()
		{
			_currentState.Tick();
		}

		#endregion
	}
}