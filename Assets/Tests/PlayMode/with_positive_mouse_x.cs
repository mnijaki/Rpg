using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode.a_player
{
	public class with_positive_mouse_x
	{
		[UnityTest]
		public IEnumerator turns_right()
		{
			yield return Helpers.LoadPlayerTestsScene();
			Player player = Helpers.GetPlayer();
			
			// MN:TO_DO: divide?
			player.PlayerInput.MouseX.Returns(1.0F);
			
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