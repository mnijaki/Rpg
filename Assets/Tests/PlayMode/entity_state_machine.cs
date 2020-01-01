using System.Collections;
using N_RPG.N_Player;
using N_RPG.N_StateMachines.N_Entity;
using N_RPG.N_StateMachines.N_Entity.N_Data;
using N_Tests.N_PlayMode.N_a_player;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace N_Tests.N_PlayMode.N_state_machine
{
	public class entity_state_machine
	{
		[UnityTest]
		public IEnumerator start_in_idle_state()
		{
			yield return Helpers.LoadEntityStateMachineTestsScene();
			EntityStateMachine stateMachine = Object.FindObjectOfType<EntityStateMachine>();
			
			Assert.AreEqual(typeof(EntityIdle), stateMachine.CurrentStateType);
		}
		
		[UnityTest]
		public IEnumerator switch_to_chase_player_state_when_in_chase_range()
		{
			yield return Helpers.LoadEntityStateMachineTestsScene();
			Player player = Helpers.GetPlayer();
			EntityStateMachine stateMachine = Object.FindObjectOfType<EntityStateMachine>();
			
			player.transform.position = stateMachine.transform.position + new Vector3(5.9F, 0.0F, 0.0F);
			yield return null;
			
			Assert.AreEqual(typeof(EntityIdle), stateMachine.CurrentStateType);

			player.transform.position = stateMachine.transform.position + new Vector3(4.9F, 0.0F, 0.0F);
			yield return null;

			Assert.AreEqual(typeof(EntityChasePlayer), stateMachine.CurrentStateType);
		}
	}
}