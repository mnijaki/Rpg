using UnityEngine;

/// <summary>
///   Logger for inventory item.
/// </summary>
public class ItemLogger : ItemComponent
{
	#region Public methods
	
	/// <summary>
	///   Use item.
	/// </summary>
	public override void Use()
	{
		Debug.Log("Item was used");
	}
	
	#endregion
}