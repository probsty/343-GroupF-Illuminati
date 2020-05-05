using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace SA
{
	public class BlockInstance 
	{
		public CardInstance attacker;
		public List<CardInstance> blocker = new List<CardInstance>();
	}
}
