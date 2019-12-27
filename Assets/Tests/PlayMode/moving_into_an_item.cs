using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode.a_player
{
	public class moving_into_an_item
	{
		[UnityTest]
		public IEnumerator picks_up_and_equips_item()
		{
			yield return Helpers.LoadPlayerTestsScene();
			Player player = Helpers.GetPlayer();
			Item item = Object.FindObjectOfType<Item>();
			Inventory inventory = player.GetComponent<Inventory>();

			Assert.AreNotSame(item, inventory.ActiveItem);

			player.PlayerInput.Vertical.Returns(1.0F);
			yield return new WaitForSeconds(5.0F);
			
			Assert.AreSame(item, inventory.ActiveItem);
		}
	}
}