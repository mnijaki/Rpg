using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode.a_player
{
	public class with_negative_mouse_x
	{
		[UnityTest]
		public IEnumerator turns_left()
		{
			Helpers.CreateFloor();
			Player player = Helpers.CreatePlayer();
			
			player.PlayerInput.MouseX.Returns(-1.0F);
			
			Quaternion startRotation = player.transform.rotation;
			const int MAX_ANGLE = 180;
			int currentAngle = 0;
			while(currentAngle < MAX_ANGLE)
			{
				currentAngle++;
				
				yield return null;
				
				// This will return negative value if we have turned left and positive if we have turned right.
				float turnAmount = Helpers.CalculateTurn(startRotation, player.transform.rotation);
				Assert.Less(turnAmount, 0.0F);
			}
		}
	}
}