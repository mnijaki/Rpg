using System.Collections.Generic;
using N_RPG.N_StateMachines.N_Data;
using N_RPG.N_StateMachines.N_Tools;
using NSubstitute;
using NUnit.Framework;

namespace N_Tests.N_EditMode
{
	public class state_machine_controller
	{
		/// <summary>
		///   A Test behaves as an ordinary method.
		/// </summary>
		[Test]
		public void example_test()
		{
			// Arrange.
			List<string> strings = new List<string>();

			// Act.
			strings.Add("Test string 1");
			strings.Add("Test string 2");
			strings.RemoveAt(0);

			// Assert.
			// Most of the times this is not appropriate checking for test (this is standard
			// .NET comparison for objects). Use 'Assert.AreEquals()' instead.
			// Assert.Equals()
			Assert.AreEqual(1, strings.Count);
		}
		
		
		[Test]
		public void initial_change_state_switches_to_state()
		{
			StateMachineController stateMachineController = new StateMachineController();
			IState firstState = Substitute.For<IState>();
			stateMachineController.Add(firstState);
			
			stateMachineController.ChangeState(firstState);
			
			Assert.AreSame(firstState, stateMachineController.CurrentState);
		}
		
		[Test]
		public void second_change_state_switches_to_second_state()
		{
			StateMachineController stateMachineController = new StateMachineController();
			IState firstState = Substitute.For<IState>();
			stateMachineController.Add(firstState);
			IState secondState = Substitute.For<IState>();
			stateMachineController.Add(secondState);
			
			stateMachineController.ChangeState(firstState);
			Assert.AreSame(firstState, stateMachineController.CurrentState);
			
			stateMachineController.ChangeState(secondState);
			Assert.AreSame(secondState, stateMachineController.CurrentState);
		}
		
		[Test]
		public void transition_switch_state_when_condition_is_met()
		{
			StateMachineController stateMachineController = new StateMachineController();
			IState firstState = Substitute.For<IState>();
			stateMachineController.Add(firstState);
			IState secondState = Substitute.For<IState>();
			stateMachineController.Add(secondState);

			bool ShouldTransitionToState() => true;
			stateMachineController.AddStateTransition(firstState,secondState, ShouldTransitionToState);
			
			stateMachineController.ChangeState(firstState);
			Assert.AreSame(firstState, stateMachineController.CurrentState);
			
			stateMachineController.Tick();
			Assert.AreSame(secondState, stateMachineController.CurrentState);
		}
		
		[Test]
		public void transition_does_not_switch_state_when_condition_is_not_met()
		{
			StateMachineController stateMachineController = new StateMachineController();
			IState firstState = Substitute.For<IState>();
			stateMachineController.Add(firstState);
			IState secondState = Substitute.For<IState>();
			stateMachineController.Add(secondState);

			bool ShouldTransitionToState() => false;
			stateMachineController.AddStateTransition(firstState,secondState, ShouldTransitionToState);
			
			stateMachineController.ChangeState(firstState);
			Assert.AreSame(firstState, stateMachineController.CurrentState);
			
			stateMachineController.Tick();
			Assert.AreSame(firstState, stateMachineController.CurrentState);
		}
	}
}