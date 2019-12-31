using N_RPG.N_Player.N_Inventory.N_Item;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace N_RPG.N_UI.N_Hotbar
{
	/// <summary>
	///   Hotbar slot.
	/// </summary>
	public class Slot : MonoBehaviour
	{
		#region Public fields

		/// <summary>
		///   Item in the slot.
		/// </summary>
		public Item Item { get; private set; }

		/// <summary>
		///   Flag if slot is empty.
		/// </summary>
		public bool IsEmpty
		{
			get { return Item == null; }
		}

		/// <summary>
		///   Slot icon image.
		/// </summary>
		public Image IconImage
		{
			get { return _iconImage; }
		}

		#endregion

		#region Serialized fields

		/// <summary>
		///   Slot icon image.
		/// </summary>
		[SerializeField]
		[Tooltip("Slot icon image")]
		private Image _iconImage;

		/// <summary>
		///   Text displayed in the slot.
		/// </summary>
		[SerializeField]
		[Tooltip("Text displayed in the slot.")]
		private TMP_Text _text;

		#endregion

		#region Public methods

		/// <summary>
		///   Set item in the slot.
		/// </summary>
		/// <param name="item">Item to set in the slot</param>
		public void SetItem(Item item)
		{
			Item = item;
			_iconImage.sprite = item.Icon;
		}

		#endregion

		#region Protected and private methods

		/// <summary>
		///   On validate.
		/// </summary>
		private void OnValidate()
		{
			_iconImage = GetComponentsInChildren<Image>()[1];
			_text = GetComponentInChildren<TMP_Text>();

			int keyNumber = transform.GetSiblingIndex() + 1;
			_text.SetText(keyNumber.ToString());

			gameObject.name = "Slot " + keyNumber;
		}

		#endregion
	}
}