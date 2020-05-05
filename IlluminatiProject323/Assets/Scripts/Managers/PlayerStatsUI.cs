using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SA
{
	public class PlayerStatsUI : MonoBehaviour
	{
		public PlayerHolder player;
		public Image playerPotrait;
		public Text health;
		public Text userName;
		
		public void UpdateAll()
		{
			UpdateUsername();
			UpdateHealth();

		}

		public void UpdateUsername()
		{
			userName.text = player.username;
			playerPotrait.sprite = player.potrait;
		}

	

		public void UpdateHealth()
		{
			health.text = player.health.ToString();
		}
		
	}
}
