using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode
{
	public class a_moving_cube
	{
		// A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
		// `yield return null;` to skip a frame.
		// To see how unity test work, on MonoBehaviour switch to 'scene' tab during test.
		[UnityTest]
		public IEnumerator object_moving_forward_changes_position()
		{
			// Arrange.
			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.transform.position = Vector3.zero;

			for(int i = 0; i < 10; i++)
			{
				// Act.
				cube.transform.position += Vector3.forward;
				yield return new WaitForSeconds(0.2F);

				// Assert.
				Assert.AreEqual(i + 1, cube.transform.position.z);
			}
		}

		[UnityTest]
		public IEnumerator object_is_rotated_90_degrees_in_z_axis()
		{
			// Arrange.
			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.transform.position = Vector3.zero;

			// Act.
			cube.transform.Rotate(Vector3.forward, 90);
			yield return new WaitForSeconds(3.0F);

			// Assert.
			Assert.AreEqual(90, cube.transform.rotation.eulerAngles.z, 0.1F);
		}
	}
}