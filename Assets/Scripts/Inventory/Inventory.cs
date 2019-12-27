using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	#region Public fields
	
	/// <summary>
	///   Currently active item.
	/// </summary>
	public Item ActiveItem { get; private set; }
	
	#endregion
	
	#region Serialized fields
	
	/// <summary>
	///   Transform representing right hand position of player.
	/// </summary>
	[SerializeField]
	[Tooltip("Transform representing right hand position of player")]
	private Transform _rightHand;
	
	#endregion
	
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
	
	/// <summary>
	///   Pick up given item.
	/// </summary>
	/// <param name="item">Item to pick up</param>
	public void Pickup(Item item)
	{
		_items.Add(item);
		item.transform.SetParent(_itemsRoot);
		Equip(item);
	}

	#endregion
	
	#region Protected and private methods

	/// <summary>
	///   Awake.
	/// </summary>
	private void Awake()
	{
		_itemsRoot = new GameObject("Items").transform;
		_itemsRoot.transform.SetParent(transform);
	}
	
	/// <summary>
	///   Equip given item.
	/// </summary>
	/// <param name="item">Item to equip</param>
	private void Equip(Item item)
	{
		// MN:TO_DO:Delete this
		Debug.Log($"Equipped item [{item.gameObject.name}]");
		
		Transform trans = item.transform;
		trans.SetParent(_rightHand);
		trans.localPosition = Vector3.zero;
		trans.localRotation = Quaternion.identity;

		ActiveItem = item;
	}

	#endregion
}