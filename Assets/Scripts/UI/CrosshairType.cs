using UnityEngine;

/// <summary>
///   Crosshair type.
/// </summary>
[CreateAssetMenu(menuName = "Crosshair type", fileName = "CrosshairType")]
public class CrosshairType : ScriptableObject
{
	#region Public fields
	
	/// <summary>
	///   Sprite representing crosshair.
	/// </summary>
	public Sprite Sprite
	{
		get { return _sprite; }
	}
	
	#endregion
	
	#region Serialized fields

	/// <summary>
	///   Sprite representing crosshair.
	/// </summary>
	[SerializeField]
	[Tooltip("Sprite representing crosshair")]
	private Sprite _sprite;

	#endregion
}