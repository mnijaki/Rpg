using NSubstitute;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace Tests.PlayMode.a_player
{
	public static class Helpers
	{
		#region Protected and private fields
		
		private static CrossAndDotDrawer _crossAndDotDrawer;
		
		#endregion
		
		#region Public methods
		
		public static void CreateFloor()
		{
			GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
			floor.transform.localScale = new Vector3(50.0F, 0.1F, 50.0F);
			floor.transform.position = Vector3.zero;
		}

		public static Player CreatePlayer()
		{
			GameObject playerGameObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
			playerGameObject.AddComponent<CharacterController>();
			playerGameObject.AddComponent<NavMeshAgent>();
			playerGameObject.transform.position = new Vector3(0.0F, 5.0F, 0.0F);
			
			IPlayerInput playerInput = Substitute.For<IPlayerInput>();
			Player player = playerGameObject.AddComponent<Player>();
			player.PlayerInput = playerInput;

			return player;
		}
		
		public static float CalculateTurn(Quaternion startRotation, Quaternion endRotation)
		{
			if(_crossAndDotDrawer == null)
			{
				_crossAndDotDrawer = Object.FindObjectOfType<Player>().gameObject.AddComponent<CrossAndDotDrawer>();
			}
			
			// Cross:
			// ♥ Cross product of two vectors A and B:
			//   ○ Returns another vector, that is perpendicular to the vectors A and B
			// ♥ Example:
			//   ○ Finding the axis around which to apply torque in order to rotate tank's turret.
			//     ♦ Lets say A is vector where turret is currently facing
			//     ♦ Lets say B is vector where turret should face to fire at some enemy
			//     ♦ When you get Cross of those two vectors you will find the axis around which to apply rotational torque.
			Vector3 cross = Vector3.Cross(startRotation * Vector3.forward, endRotation * Vector3.forward);
			
			// Dot:
			// ♥ Dot product of two vectors A and B:
			//   ○ float dot = (Ax * Bx) + (Ay * By) + (Az + Bz)
			// ♥ Info:
			//   ○ The dot product takes two vectors and returns a scalar.
			//     This scalar is equal to the magnitudes of the two vectors multiplied together and the result multiplied by the cosine of the angle between the vectors.
			//     When both vectors are normalized, the cosine essentially states how far the first vector extends in the second’s direction
			//     (or vice-versa - the order of the parameters doesn’t matter).
			//     Cosine values are positive in ranges of [0-90] and [270-360] degrees.
			//     Cosine values are negative in range of [90-270] degrees.
			// ♥ Link:
			//   ○ https: //docs.unity3d.com/Manual/UnderstandingVectorArithmetic.html
			// ♥ Why use it?:
			//   ○ The dot product is a very simple operation that can be used in place of the Mathf.Cos function or
			//     the vector magnitude operation in some circumstances (it doesn’t do exactly the same thing but sometimes the effect is equivalent).
			//     However, calculating the dot product function takes much less CPU time and so it can be a valuable optimization.
			// ♥ Dot values:
			//   ○ (dot = 0) then two vectors are perpendicular to one another
			//   ○ (dot > 0) then angle between two vectors is less than 90 degrees
			//   ○ (dot < 0) then angle between two vectors is more than 90 degrees
			// ♥ Dot values of normalized vectors:
			//   ○ (dot = 0) then two vectors vectors are perpendicular
			//   ○ (dot = 1) then two vectors point in exactly the same direction
			//   ○ (dot = -1) then two vectors point in completely opposite directions
			// ♥ Dot values in comparison of vectors length:
			//   ○ |A dot B| <= Len(A) dot Len(B)
			//   ○ |A dot B| = Len(A) dot Len(B), and one of vector is scalar vector of other, eg A = c * B;
			float dot = Vector3.Dot(cross, Vector3.up);
			
			_crossAndDotDrawer.UpdateValues(startRotation * Vector3.forward, endRotation * Vector3.forward, cross, dot);

			return dot;
		}
		
		private class CrossAndDotDrawer : MonoBehaviour
		{
			private Vector3 _crossStartVector;
			private Vector3 _crossEndVector;
			private Vector3 _cross;
			private float _dot;

			public void UpdateValues(Vector3 crossStartVector, Vector3 crossEndVector, Vector3 cross, float dot)
			{
				_crossStartVector = crossStartVector;
				_crossEndVector = crossEndVector;
				_cross = cross;
				_dot = dot;
			}
		
			private void OnDrawGizmos()
			{
				Vector3 origin = new Vector3(0.0F, 1.5F, 0.0F);

				GUI.color = Color.red;
				Handles.Label(new Vector3(_crossStartVector.x * 2,1.5F,_crossStartVector.z *2), "CrossStartVector");
				Gizmos.color = Color.red;
				Gizmos.DrawRay(origin, _crossStartVector * 4);
			
				GUI.color = Color.yellow;
				Handles.Label(new Vector3(_crossEndVector.x * 2,1.5F,_crossEndVector.z *2), "CrossEndVector");
				Gizmos.color = Color.yellow;
				Gizmos.DrawRay(origin, _crossEndVector * 4);
			
				GUI.color = Color.green;
				Handles.Label(new Vector3(_cross.x * 2,1.5F,_cross.z *2), "Cross");
				Gizmos.color = Color.green;
				Gizmos.DrawRay(origin, _cross * 4);
			
				GUI.color = Color.magenta;
				Handles.Label(new Vector3(Vector3.up.x * 2,1.5F,Vector3.up.z *2), "Up");
				Gizmos.color = Color.magenta;
				Gizmos.DrawRay(new Vector3(0.1F, 0.0F, 0.0F), Vector3.up * 4);
				
				Handles.Label(new Vector3(2,0,0), $"DOT = {_dot}");
			}
		}
		
		#endregion
	}
}