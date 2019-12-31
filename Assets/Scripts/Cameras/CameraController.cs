using UnityEngine;

namespace N_RPG.N_Cameras
{
	/// <summary>
	///   Camera controller
	/// </summary>
	public class CameraController : MonoBehaviour
	{
		#region Serialized fields

		/// <summary>
		///   Sensitivity of camera tilt.
		/// </summary>
		[SerializeField]
		[Range(0.1F, 10.0F)]
		[Tooltip("Sensitivity of camera tilt.")]
		private float _tiltSensitivity = 2.0F;

		/// <summary>
		///   Minimum tilt in X axis.
		/// </summary>
		[SerializeField]
		[Range(-45.0F, 0.0F)]
		[Tooltip("Minimum tilt in X axis.")]
		private float _minTiltX = -30.0F;

		/// <summary>
		///   Maximum tilt in X axis.
		/// </summary>
		[SerializeField]
		[Range(0.0F, 45.0F)]
		[Tooltip("Maximum tilt in X axis.")]
		private float _maxTiltX = 30.0F;

		#endregion
		
		#region Protected and private fields

		/// <summary>
		///   Tilt of camera in X axis.
		/// </summary>
		private float _tiltX;

		#endregion

		#region Protected and private methods

		/// <summary>
		///   Update.
		/// </summary>
		private void Update()
		{
			TiltCameraAxisX();
		}

		/// <summary>
		///   Tilt camera in X axis.
		/// </summary>
		private void TiltCameraAxisX()
		{
			float inputRotationY = Input.GetAxis("Mouse Y") * _tiltSensitivity;
			_tiltX = Mathf.Clamp(_tiltX - inputRotationY, _minTiltX, _maxTiltX);
			transform.localRotation = Quaternion.Euler(_tiltX, 0.0F, 0.0F);
		}

		#endregion
	}
}