using System.Collections;
using N_RPG.N_Player;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace N_Tests.N_PlayMode.N_a_player
{
	public class with_positive_mouse_x
	{
		[UnityTest]
		public IEnumerator turns_right()
		{
			yield return Helpers.LoadPlayerTestsScene();
			Player player = Helpers.GetPlayer();
			
			player.PlayerInput.MouseX.Returns(1.0F / player.Rotator.RotatorType.Sensitivity);
			
			Quaternion startRotation = player.transform.rotation;
			const int MAX_ANGLE = 180;
			int currentAngle = 0;
			while(currentAngle < MAX_ANGLE)
			{
				yield return null;
				
				// This will return negative value if we have turned left and positive if we have turned right.
				float turnAmount = Helpers.CalculateTurn(startRotation, player.transform.rotation);
				Assert.Greater(turnAmount, 0.0F);
				
				currentAngle++;
			}
		}
	}
}