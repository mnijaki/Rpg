using UnityEngine;

public class ItemLogger : ItemComponent
{
	#region Protected and private methods
	
	/// <summary>
	///   Use item.
	/// </summary>
	protected override void Use()
	{
		Debug.Log("Item was used");
	}
	
	#endregion
}