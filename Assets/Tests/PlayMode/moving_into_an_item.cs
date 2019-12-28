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
		[UnityTest]
		public IEnumerator picks_up_and_equips_item()
		{
			yield return Helpers.LoadPlayerItemTestsScene();
			Player player = Helpers.GetPlayer();
			Item item = Object.FindObjectOfType<Item>();
			Inventory inventory = player.GetComponent<Inventory>();

			Assert.AreNotSame(item, inventory.ActiveItem);

			player.PlayerInput.Vertical.Returns(1.0F);
			yield return new WaitForSeconds(5.0F);
			
			Assert.AreSame(item, inventory.ActiveItem);
		}
		
		[UnityTest]
		public IEnumerator changes_crosshair_to_item_crosshair()
		{
			yield return Helpers.LoadPlayerItemTestsScene();
			Player player = Helpers.GetPlayer();
			Item item = Object.FindObjectOfType<Item>();
			Crosshair crosshair = Object.FindObjectOfType<Crosshair>();

			Assert.AreNotSame(item.CrosshairType.Sprite, crosshair.GetComponent<Image>().sprite);

			// Set position immediate to reduce the test time.
			item.transform.position = player.transform.position;
			yield return null;
			
			Assert.AreEqual(item.CrosshairType.Sprite, crosshair.GetComponent<Image>().sprite);
		}
	}
}