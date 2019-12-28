using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///   Crosshair.
/// </summary>
public class Crosshair : MonoBehaviour
{
	#region Serialized fields

	/// <summary>
	///   Image component responsible for displaying crosshair sprite.
	/// </summary>
	[SerializeField]
	[Tooltip("Image component responsible for displaying crosshair sprite")]
	private Image _crosshairImage;
	
	[SerializeField]
	private Sprite _gunSprite;
	
	[SerializeField]
	private Sprite _invalidSprite;

	#endregion

	#region Protected and private fields

	/// <summary>
	///   Player inventory.
	/// </summary>
	private Inventory _inventory;

	#endregion

	#region Protected and private methods

	/// <summary>
	///   On enable.
	/// </summary>
	private void OnEnable()
	{
		_inventory = FindObjectOfType<Inventory>();
		_inventory.ActiveItemChanged += InventoryOnActiveItemChanged;

		if(_inventory.ActiveItem != null)
		{
			InventoryOnActiveItemChanged(_inventory.ActiveItem);
		}
		else
		{
			_crosshairImage.sprite = _invalidSprite;
		}
	}

	/// <summary>
	///   On validate.
	/// </summary>
	private void OnValidate()
	{
		_crosshairImage = GetComponent<Image>();
	}

	#endregion

	#region Events handlers

	/// <summary>
	///   Event - on active item changed in inventory.
	/// </summary>
	/// <param name="newActiveItem">New active item.</param>
	private void InventoryOnActiveItemChanged(Item newActiveItem)
	{
		switch(newActiveItem.CrosshairType)
		{
			case CrosshairType.Gun:
			{
				_crosshairImage.sprite = _gunSprite;
				break;
			}
			case CrosshairType.Invalid:
			{
				_crosshairImage.sprite = _invalidSprite;
				break;
			}
		}
		
		Debug.Log($"Crosshair detected new item [{newActiveItem.CrosshairType}]");
	}

	#endregion
}