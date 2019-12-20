using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode.a_player
{
	public class with_negative_horizontal_input
	{
		[UnityTest]
		public IEnumerator moves_left()
		{
			yield return Helpers.LoadMovementAndRotationTestsScene();
			Player player = Helpers.GetPlayer();

			// Wait so position of player GameObject will be set appropriate.
			yield return null;

			player.PlayerInput.Horizontal.Returns(-5.0F);
			
			float startXPosition = player.transform.position.x;
			yield return new WaitForSeconds(2.0F);
			float endXPosition = player.transform.position.x;
			
			Assert.Less(endXPosition, startXPosition);
		}
	}
}