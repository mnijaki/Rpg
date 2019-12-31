using RPG.StateMachines.Data;
using UnityEngine;

namespace RPG.StateMachines.Entity.Data
{
	/// <summary>
	///   Entity idle state.
	/// </summary>
	public class EntityIdle : IState
	{
		#region Public methods
	
		/// <summary>
		///   Tick.
		/// </summary>
		public void Tick()
		{
			Debug.Log("Idle");
		}

		/// <summary>
		///   On enter to the state.
		/// </summary>
		public void OnEnter()
		{
		
		}

		/// <summary>
		///   On exit from the state.
		/// </summary>
		public void OnExit()
		{
		
		}
	
		#endregion
	}
}
