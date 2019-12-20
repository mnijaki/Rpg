using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode.a_player
{
	public class with_negative_vertical_input
	{
		[UnityTest]
		public IEnumerator moves_backwards()
		{
			Helpers.CreateFloor();
			Player player = Helpers.CreatePlayer();

			// Wait so position of player GameObject will be set appropriate.
			yield return null;

			player.PlayerInput.Vertical.Returns(-5.0F);
			
			float startZPosition = player.transform.position.z;
			yield return new WaitForSeconds(2.0F);
			float endZPosition = player.transform.position.z;
			
			Assert.Less(endZPosition, startZPosition);
		}
	}
}