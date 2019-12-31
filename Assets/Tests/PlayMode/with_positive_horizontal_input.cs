using System.Collections;
using N_RPG.N_Player;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace N_Tests.N_PlayMode.N_a_player
{
	public class with_positive_horizontal_input
	{
		[UnityTest]
		public IEnumerator moves_right()
		{
			yield return Helpers.LoadPlayerTestsScene();
			Player player = Helpers.GetPlayer();

			// Wait so position of player GameObject will be set appropriate.
			yield return null;

			player.PlayerInput.Horizontal.Returns(5.0F / player.Mover.MoverType.Sensitivity);
			
			float startXPosition = player.transform.position.x;
			yield return new WaitForSeconds(2.0F);
			float endXPosition = player.transform.position.x;
			
			Assert.Greater(endXPosition, startXPosition);
		}
	}
}