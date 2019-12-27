using UnityEngine;

/// <summary>
///   Inventory item component (building element of inventory item). 
/// </summary>
public abstract class ItemComponent : MonoBehaviour
{
	#region Public fields

	/// <summary>
	///   Flag if item can be used.
	/// </summary>
	public bool CanBeUsed
	{
		get { return Time.time > _nextUseTime; }
	}

	#endregion
	
	#region Protected and private fields

	/// <summary>
	///   Time, when item can be used again.
	/// </summary>
	protected float _nextUseTime;

	#endregion

	#region Public methods

	/// <summary>
	///   Use item.
	/// </summary>
	public abstract void Use();

	#endregion
}