using System;
using System.Collections.Generic;
using N_RPG.N_StateMachines.N_Data;
using UnityEngine;

namespace N_RPG.N_StateMachines.N_Tools
{
	/// <summary>
	///   State machine controller.
	/// </summary>
	public class StateMachineController
	{
		#region Public fields

		/// <summary>
		///   Current state.
		/// </summary>
		public IState CurrentState { get; private set; }
		
		#endregion
		
		#region Protected and private fields

		/// <summary>
		///   Collection of all available states.
		/// </summary>
		private readonly List<IState> _states = new List<IState>();
		
		/// <summary>
		///   Collection of all available transitions between states.
		///   <para></para>
		///   Each state can have more than one state it can go to (if given condition is met then appropriate state is chosen).    
		/// </summary>
		private readonly Dictionary<IState,List<StateTransition>> _statesTransitions = new Dictionary<IState, List<StateTransition>>();
		
		/// <summary>
		///   Collection of all available transitions from any state to new state.
		///   <para></para>
		///   Transition from this collection can only be used if associated condition is met.
		/// </summary>
		private readonly List<StateTransition> _anyStateTransitions = new List<StateTransition>();

		#endregion

		#region Public methods

		/// <summary>
		///   Change state.
		/// </summary>
		/// <param name="newState">New state of state machine</param>
		public void ChangeState(IState newState)
		{
			if(CurrentState == newState)
			{
				return;
			}

			CurrentState?.OnExit();
			CurrentState = newState;
			CurrentState.OnEnter();

			Debug.Log($"Changed state to [{newState}]");
		}

		/// <summary>
		///   Tick.
		/// </summary>
		public void Tick()
		{
			TryChangeState();

			CurrentState.Tick();
		}

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
		///   Add transition between two states.
		/// </summary>
		/// <param name="oldState">Old state (state that we are transitioning from)</param>
		/// <param name="newState">New state (state that we are transitioning to)</param>
		/// <param name="condition">Condition that must be met to transition from old state to new state</param>
		public void AddStateTransition(IState oldState, IState newState, Func<bool> condition)
		{
			if(!_statesTransitions.ContainsKey(oldState))
			{
				_statesTransitions.Add(oldState, new List<StateTransition>());
			}
			
			_statesTransitions[oldState].Add(new StateTransition(oldState, newState, condition));
		}
		
		/// <summary>
		///   Add transition from any state.
		/// </summary>
		/// <param name="newState">New state (state that we are transitioning to)</param>
		/// <param name="condition">Condition that must be met to make transition to new state</param>
		public void AddAnyStateTransition(IState newState, Func<bool> condition)
		{
			_anyStateTransitions.Add(new StateTransition(null, newState, condition));
		}

		#endregion
		
		#region Protected and private methods
		
		/// <summary>
		///   Try change state.
		/// </summary>
		private void TryChangeState()
		{
			StateTransition stateTransition = GetStateTransition();
			if(stateTransition != null)
			{
				ChangeState(stateTransition.NewState);
			}
		}
		
		/// <summary>
		///   Get state transition.
		/// </summary>
		/// <returns>State to transit to</returns>
		private StateTransition GetStateTransition()
		{
			foreach(StateTransition stateTransition in _anyStateTransitions)
			{
				if(stateTransition.Condition())
				{
					return stateTransition;
				}
			}
			
			if((CurrentState == null) || (!_statesTransitions.ContainsKey(CurrentState)))
			{
				return null;
			}
			
			foreach(StateTransition stateTransition in _statesTransitions[CurrentState])
			{
				if(stateTransition.Condition())
				{
					return stateTransition;
				}
			}

			return null;
		}
		
		#endregion
	}
}