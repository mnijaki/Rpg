using RPG.StateMachines.Data;
using UnityEngine.AI;

namespace RPG.StateMachines.Entity.Data
{
	/// <summary>
	///   Entity chase player state.
	/// </summary>
	public class EntityChasePlayer : IState
	{
		#region Protected and private fields
	
		/// <summary>
		///   NavMeshAgent used for navigation of entity.
		/// </summary>
		private readonly NavMeshAgent _navMeshAgent;
	
		#endregion

		#region Public methods

		/// <summary>
		///   Constructor.
		/// </summary>
		/// <param name="navMeshAgent">NavMeshAgent used for navigation of entity</param>
		public EntityChasePlayer(NavMeshAgent navMeshAgent)
		{
			_navMeshAgent = navMeshAgent;
		}
	
		/// <summary>
		///   Tick.
		/// </summary>
		public void Tick()
		{
		
		}

		/// <summary>
		///   On enter to the state.
		/// </summary>
		public void OnEnter()
		{
			_navMeshAgent.enabled = true;
		}

		/// <summary>
		///   On exit from the state.
		/// </summary>
		public void OnExit()
		{
			_navMeshAgent.enabled = false;
		}
	
		#endregion
	}
}

