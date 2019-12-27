using UnityEngine;

/// <summary>
///   Class handling usage of inventory.  
/// </summary>
[RequireComponent(typeof(Inventory))]
public class InventoryUse : MonoBehaviour
{
	#region Protected and private fields
	
	/// <summary>
	///   Inventory which will be used.
	/// </summary>
	private Inventory _inventory;
	
	#endregion

	#region Protected and private methods
	
	/// <summary>
	///   Awake.
	/// </summary>
	private void Awake()
	{
		_inventory = GetComponent<Inventory>();
	}

	/// <summary>
	///   Update.
	/// </summary>
	private void Update()
	{
		if(_inventory.ActiveItem == null)
		{
			return;
		}

		foreach(UseAction useAction in _inventory.ActiveItem.UseActions)
		{
			if((!CanCallAction(useAction.RaiseEvent)) || (!useAction.TargetComponent.CanBeUsed))
			{
				continue;
			}
			
			useAction.TargetComponent.Use();
		}
	}

	/// <summary>
	///   Returns a flag whether a given use action can be called on given raise event.
	/// </summary>
	/// <param name="raiseEvent">Event to raise</param>
	/// <returns>Flag whether a given use action can be called on given raise event</returns>
	private static bool CanCallAction(RaiseEvent raiseEvent)
	{
		switch(raiseEvent)
		{
			case RaiseEvent.LeftClick:
			{
				return Input.GetMouseButtonDown(0);
			}
			case RaiseEvent.RightClick:
			{
				return Input.GetMouseButtonDown(1);
			}
			default:
			{
				return false;
			}
		}
	}

	#endregion
}