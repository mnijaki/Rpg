using UnityEngine;

namespace N_RPG.N_Player.N_Movement
{
	/// <summary>
	///   Mover type.
	/// </summary>
	[CreateAssetMenu(menuName = "Mover type", fileName = "MoverType")]
	public class MoverType : ScriptableObject
	{
		#region Public fields

		/// <summary>
		///   Movement sensitivity.
		/// </summary>
		public float Sensitivity
		{
			get { return _sensitivity; }
		}

		#endregion

		#region Serialized fields

		/// <summary>
		///   Movement sensitivity.
		/// </summary>
		[SerializeField]
		[Tooltip("Movement sensitivity")]
		private float _sensitivity = 5.0F;

		#endregion
	}
}