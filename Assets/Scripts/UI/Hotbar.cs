using UnityEngine;

/// <summary>
///   UI hotbar with slots.
/// </summary>
public class Hotbar : MonoBehaviour
{
	#region Protected and private fields
	
	/// <summary>
	///   Player.
	/// </summary>
	private Player _player;
	
	/// <summary>
	///   Player inventory.
	/// </summary>
	private Inventory _inventory;
	
	/// <summary>
	///   Collection of slots.
	/// </summary>
	private Slot[] _slots;

	#endregion

	#region Protected and private methods

	/// <summary>
	///   On enable.
	/// </summary>
	private void OnEnable()
	{
		_player = FindObjectOfType<Player>();
		_player.PlayerInput.AlphaKeyPressed += PlayerInputOnAlphaKeyPressed;
		_inventory = FindObjectOfType<Inventory>();
		_inventory.ItemPickedUp += InventoryOnItemPickedUp;
		_slots = GetComponentsInChildren<Slot>();
	}

	/// <summary>
	///   On disable.
	/// </summary>
	private void OnDisable()
	{
		_player.PlayerInput.AlphaKeyPressed -= PlayerInputOnAlphaKeyPressed;
		_inventory.ItemPickedUp -= InventoryOnItemPickedUp;
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
	///   Event - fired after Alpha key was pressed.
	/// </summary>
	/// <param name="index">Index of pressed Alpha key (0 - Alpha1, 1 - Alpha2, 2 - Alpha3...)</param>
	private void PlayerInputOnAlphaKeyPressed(int index)
	{
		if((index < 0) || (index >= _slots.Length))
		{
			return;
		}
		
		if(_slots[index].IsEmpty == false)
		{
			_inventory.Equip(_slots[index].Item);
		}
	}

	/// <summary>
	///   Event - fired when item was picked up to inventory. 
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