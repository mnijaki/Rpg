using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	#region Protected and private fields
	
	/// <summary>
	///   List of inventory items.
	/// </summary>
	private readonly List<Item> _items = new List<Item>();
	
	/// <summary>
	///   Root transform for items (all items will be attached under this object).
	/// </summary>
	private Transform _itemsRoot;

	#endregion

	#region Public methods
	
	public void Pickup(Item item)
	{
		_items.Add(item);
		item.transform.SetParent(_itemsRoot);
		Equip(item);
	}

	#endregion
	
	#region Protected and private methods

	private void Awake()
	{
		_itemsRoot = new GameObject("Items").transform;
		_itemsRoot.transform.SetParent(transform);
	}
	
	private void Equip(Item item)
	{
		Debug.Log($"Equipped item [{item.gameObject.name}]");
	}

	#endregion
}