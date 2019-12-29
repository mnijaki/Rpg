using System.Collections.Generic;
using UnityEngine;

/// <summary>
///   UI hotbar with slots.
/// </summary>
public class Hotbar : MonoBehaviour
{
	#region Protected and private fields
	
	/// <summary>
	///   Player inventory..
	/// </summary>
	private Inventory _inventory;
	
	/// <summary>
	///   Collection of slots.
	/// </summary>
	private IEnumerable<Slot> _slots;

	#endregion

	#region Protected and private methods

	/// <summary>
	///   On enable.
	/// </summary>
	private void OnEnable()
	{
		_inventory = FindObjectOfType<Inventory>();
		_inventory.ItemPickedUp += InventoryOnItemPickedUp;
		_slots = GetComponentsInChildren<Slot>();
	}

	/// <summary>
	///   Find first free slot in hotbar.
	/// </summary>
	/// <returns>First free slot</returns>
	private Slot FindFirstFreeSlot()
	{
		foreach(Slot slot in _slots)
		{
			if(slot.IsEmpty)
			{
				return slot;
			}
		}

		return null;
	}

	#endregion
	
	#region Events handlers

	/// <summary>
	///  Event - fired when item was picked up to inventory. 
	/// </summary>
	/// <param name="pickedUpItem">Picked up item</param>
	private void InventoryOnItemPickedUp(Item pickedUpItem)
	{
		Slot slot = FindFirstFreeSlot();
		if(slot != null)
		{
			slot.SetItem(pickedUpItem);
		}
	}

	#endregion
}