using System;
using N_RPG.N_Entity;
using N_RPG.N_Player;
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
		#region Public fields

		/// <summary>
		///   Current state type.
		/// </summary>
		public Type CurrentStateType
		{
			get { return _stateMachineController.CurrentState.GetType(); }
		}

		#endregion
		
		#region Protected and private fields

		/// <summary>
		///   State machine controller. 
		/// </summary>
		private StateMachineController _stateMachineController;
		
		/// <summary>
		///   NavMeshAgent used for navigation of entity.
		/// </summary>
		private NavMeshAgent _navMeshAgent;
		
		/// <summary>
		///   Entity that is being processed by entity state machine.
		/// </summary>
		private Entity _entity;

		#endregion
	
		#region Protected and private methods

		/// <summary>
		///   Awake.
		/// </summary>
		private void Awake()
		{
			_stateMachineController = new StateMachineController();
			_navMeshAgent = GetComponent<NavMeshAgent>();
			_entity = GetComponent<Entity>();
		
			EntityIdle entityIdle = new EntityIdle();
			EntityChasePlayer entityChasePlayer = new EntityChasePlayer(_navMeshAgent);
			EntityAttack entityAttack = new EntityAttack();
			EntityDead entityDead = new EntityDead();
		
			_stateMachineController.Add(entityIdle);
			_stateMachineController.Add(entityChasePlayer);
			_stateMachineController.Add(entityAttack);
			
			_stateMachineController.AddAnyStateTransition(entityDead, () => _entity.IsDead);

			Player player = FindObjectOfType<Player>();
			_stateMachineController.AddStateTransition(entityIdle, 
			                                           entityChasePlayer, 
			                                           () => FlatDistance(_navMeshAgent.transform.position, player.transform.position) < 5);
			_stateMachineController.AddStateTransition(entityChasePlayer, 
			                                           entityAttack, 
			                                           () => FlatDistance(_navMeshAgent.transform.position, player.transform.position) < 2);
		
			_stateMachineController.ChangeState(entityIdle);
		}
	
		/// <summary>
		///   Update.
		/// </summary>
		private void Update()
		{
			_stateMachineController.Tick();
		}

		/// <summary>
		///   Get distance between two points ('y' axis is ignored).
		/// </summary>
		/// <param name="source">Source point</param>
		/// <param name="target">Target point</param>
		/// <returns>Distance between two points ('y' axis is ignored).</returns>
		private static float FlatDistance(Vector3 source, Vector3 target)
		{
			return Vector3.Distance(new Vector3(source.x, 0.0F, source.z), new Vector3(target.x, 0.0F, target.z));
		}

		#endregion
	}
}
