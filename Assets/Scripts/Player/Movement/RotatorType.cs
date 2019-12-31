using UnityEngine;

namespace N_RPG.N_Player.N_Movement
{
	/// <summary>
	///   Rotator type.
	/// </summary>
	[CreateAssetMenu(menuName = "Rotator type", fileName = "RotatorType")]
	public class RotatorType : ScriptableObject
	{
		#region Public fields

		/// <summary>
		///   Rotation sensitivity.
		/// </summary>
		public float Sensitivity
		{
			get { return _sensitivity; }
		}

		#endregion

		#region Serialized fields

		/// <summary>
		///   Rotation sensitivity.
		/// </summary>
		[SerializeField]
		[Tooltip("Rotation sensitivity")]
		private float _sensitivity = 2.0F;

		#endregion
	}
}