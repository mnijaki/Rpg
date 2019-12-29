using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests.PlayMode.a_player
{
	public class moving_into_an_item
	{
		#region Protected and private fields
		
		/// <summary>
		///   Player;
		/// </summary>
		private Player _player;
		
		/// <summary>
		///   Item.
		/// </summary>
		private Item _item;
		
		#endregion

		/// <summary>
		///   Initialize method, invoked each time before given test. 
		/// </summary>
		/// <returns>IEnumerator for coroutine</returns>
		[UnitySetUp]
		public IEnumerator init()
		{
			yield return Helpers.LoadPlayerItemTestsScene();
			_player = Helpers.GetPlayer();
			_item = Object.FindObjectOfType<Item>();
		}
		
		[UnityTest]
		public IEnumerator picks_up_and_equips_item()
		{
			Inventory inventory = _player.GetComponent<Inventory>();

			Assert.AreNotSame(_item, inventory.ActiveItem);

			_player.PlayerInput.Vertical.Returns(1.0F);
			yield return new WaitForSeconds(5.0F);
			
			Assert.AreSame(_item, inventory.ActiveItem);
		}
		
		[UnityTest]
		public IEnumerator changes_crosshair_to_item_crosshair()
		{
			Crosshair crosshair = Object.FindObjectOfType<Crosshair>();

			Assert.AreNotSame(_item.CrosshairType.Sprite, crosshair.GetComponent<Image>().sprite);

			// Set position immediate to reduce the test time.
			_item.transform.position = _player.transform.position;
			// Wait till physics is processed (so collision with item would be triggered).
			yield return new WaitForFixedUpdate();
			
			Assert.AreEqual(_item.CrosshairType.Sprite, crosshair.GetComponent<Image>().sprite);
		}
		
		[UnityTest]
		public IEnumerator set_icon_in_hotbar_slot_1()
		{
			Hotbar hotbar = Object.FindObjectOfType<Hotbar>();
			Slot slot1 = hotbar.GetComponentInChildren<Slot>();

			Assert.AreNotSame(_item.Icon, slot1.IconImage.sprite);

			// Set position immediate to reduce the test time.
			_item.transform.position = _player.transform.position;
			// Wait till physics is processed (so collision with item would be triggered).
			yield return new WaitForFixedUpdate();
			
			Assert.AreEqual(_item.Icon, slot1.IconImage.sprite);
		}
	}
}