using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode.a_player
{
	public class with_positive_horizontal_input
	{
		[UnityTest]
		public IEnumerator moves_right()
		{
			// Arrange.
			GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
			floor.transform.localScale = new Vector3(50.0F, 0.1F, 50.0F);
			floor.transform.position = Vector3.zero;

			GameObject playerGameObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
			playerGameObject.AddComponent<CharacterController>();
			playerGameObject.transform.position = new Vector3(0.0F, 5.0F, 0.0F);

			// Wait so position of player GameObject will be set appropriate.
			yield return null;

			IPlayerInput playerInput = Substitute.For<IPlayerInput>();
			Player player = playerGameObject.AddComponent<Player>();
			player.PlayerInput = playerInput;
			float startingXPosition = player.transform.position.x;

			// Act.
			playerInput.Horizontal.Returns(5.0F);

			yield return new WaitForSeconds(2.0F);

			float endingXPosition = player.transform.position.x;

			// Assert.
			Assert.Greater(endingXPosition, startingXPosition);
		}
	}
}