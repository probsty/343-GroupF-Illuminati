using UnityEngine;
using System.Collections;

namespace SA
{
	[CreateAssetMenu(menuName = "Actions/Player Actions/LoadOnActiveHolder")]
	public class LoadOnActiveHolder : PlayerAction
	{
		public override void Execute(PlayerHolder player)
		{
			GameManager.singleton.LoadPlayerOnActive(player);
		}
	}
}
