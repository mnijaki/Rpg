using N_RPG.N_StateMachines.N_Entity.N_Data;
using N_RPG.N_StateMachines.N_Tools;
using UnityEngine;
using UnityEngine.AI;

namespace N_RPG.N_StateMachines.N_Entity
{
	/// <summary>
	///   Entity state machine.
	/// </summary>
	public class EntityStateMachine : MonoBehaviour
	{
		#region Protected and private fields

		/// <summary>
		///   State machine controller. 
		/// </summary>
		private StateMachineController _stateMachineController;
		
		/// <summary>
		///   NavMeshAgent used for navigation of entity.
		/// </summary>
		private NavMeshAgent _navMeshAgent;

		#endregion
	
		#region Protected and private methods

		/// <summary>
		///   Awake.
		/// </summary>
		private void Awake()
		{
			_stateMachineController = new StateMachineController();
			_navMeshAgent = GetComponent<NavMeshAgent>();
		
			EntityIdle entityIdle = new EntityIdle();
			EntityChasePlayer entityChasePlayer = new EntityChasePlayer(_navMeshAgent);
			EntityAttack entityAttack = new EntityAttack();
		
			_stateMachineController.Add(entityIdle);
			_stateMachineController.Add(entityChasePlayer);
			_stateMachineController.Add(entityAttack);
		
			_stateMachineController.ChangeState(entityIdle);
		}
	
		/// <summary>
		///   Update.
		/// </summary>
		private void Update()
		{
			_stateMachineController.Tick();
		}

		#endregion
	}
}
