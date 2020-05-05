using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA.GameStates;

namespace SA
{
	public class GameManager : MonoBehaviour
	{
		public ResourcesManager resourcesManager;
		public bool isMultiplayer;
		[System.NonSerialized]
		public PlayerHolder[] all_players;

		public PlayerHolder GetEnemyOf(PlayerHolder p)
		{
			for (int i = 0; i < all_players.Length; i++)
			{
				if (all_players[i] != p)
				{
					return all_players[i];
				}
			}

			return null;
		}
		
		public PlayerHolder currentPlayer;

		public PlayerHolder localPlayer;
		public PlayerHolder clientPlayer;
		public CardHolders playerOneHolder;
		public CardHolders otherPlayersHolder;

		public State currentState;
		public GameObject cardPrefab;

		//public int turnIndex;
		//public Turn[] turns;
		public SO.GameEvent onTurnChanged;
		public SO.GameEvent onPhaseChanged;
		//public SO.StringVariable turnText;

		Phase currentPhase;

		public PlayerStatsUI[] statsUI;
		public SO.TransformVariable graveyardVariable;
		List<CardInstance> graveyardCards = new List<CardInstance>();
		public Element defenceProperty;

		bool isInit;

		Dictionary<CardInstance, BlockInstance> blockInstances = new Dictionary<CardInstance, BlockInstance>();

		public Dictionary<CardInstance,BlockInstance> GetBlockInstances()
		{
			return blockInstances;
		}

		public void ClearBlockInstances()
		{
			blockInstances.Clear();
		}

		public void AddBlockInstance(CardInstance attacker, CardInstance blocker, ref int count)
		{
			BlockInstance b = null;
			b = GetBlockInstanceOfAttacker(attacker);
			if (b == null)
			{
				b = new BlockInstance();
				b.attacker = attacker;
				blockInstances.Add(attacker, b);
			}

			if(!b.blocker.Contains(blocker))
				b.blocker.Add(blocker);

			count = b.blocker.Count;
		}

		BlockInstance GetBlockInstanceOfAttacker(CardInstance attacker)
		{
			BlockInstance r = null;
			blockInstances.TryGetValue(attacker, out r);
			return r;
		}

		public static GameManager singleton;

		private void Awake()
		{
			Settings.gameManager = this;
			singleton = this;
		}

		public void InitGame()
		{
			isInit = true;
			//all_players = new PlayerHolder[turns.Length];
			//Turn[] _turns = new Turn[2];

			//for (int i = 0; i < turns.Length; i++)
			//{
			//	all_players[i] = turns[i].player;

			//	if (all_players[i].photonId == startingPlayer)
			//	{
			//		_turns[0] = turns[i];
			//	}
			//	else
			//	{
			//		_turns[1] = turns[i];
			//	}
			//}

			//turns = _turns;
		
			//SetupPlayers();

			//turnText.value = turns[turnIndex].player.username;
			//onTurnChanged.Raise();
			//turns[0].OnTurnStart();
			//isInit = true;
		}

		void SetupPlayers()
		{
			ResourcesManager rm = Settings.GetResourcesManager();

			for (int i = 0; i < all_players.Length; i++)
			{
				all_players[i].Init();

				if (i == 0)
				{
					all_players[i].currentHolder = playerOneHolder;
				}
				else
				{
					all_players[i].currentHolder = otherPlayersHolder;	
				}

				all_players[i].statsUI = statsUI[i];
				all_players[i].currentHolder.LoadPlayer(all_players[i], all_players[i].statsUI);
			}
		}

		public void PickNewCardFromDeck(PlayerHolder p)
		{
//			MultiplayerManager.singleton.PlayerPicksCardFromDeck(p);
		}

		public void LoadPlayerOnActive(PlayerHolder p)
		{
			PlayerHolder prevPlayer = playerOneHolder.playerHolder;
			if(prevPlayer != p)
				LoadPlayerOnHolder(prevPlayer, otherPlayersHolder, statsUI[1]);
			LoadPlayerOnHolder(p, playerOneHolder, statsUI[0]);
		}

		public void LoadPlayerOnHolder(PlayerHolder p,CardHolders h, PlayerStatsUI ui)
		{
			h.LoadPlayer(p, ui);
		}
		
		private void Update()
		{
			if (!isInit)
				return;

			if (currentPhase == null)
				return;

			bool phaseIsComplete = currentPhase.IsComplete();

			if (phaseIsComplete)
			{
				currentPhase = null;
//				MultiplayerManager.singleton.PlayerEndsPhase(localPlayer.photonId);
			}

			//bool isComplete = turns[turnIndex].Execute();

			//if (!isMultiplayer)
			//{
			//	if (isComplete)
			//	{
			//		turnIndex++;
			//		if (turnIndex > turns.Length - 1)
			//		{
			//			turnIndex = 0;
			//		}

			//		//The current player has changed here
			//		currentPlayer = turns[turnIndex].player;
			//		turns[turnIndex].OnTurnStart();
			//		turnText.value = turns[turnIndex].player.username;
			//		onTurnChanged.Raise();
			//	}
			//}
			//else
			//{
			//	if (isComplete)
			//	{
			//		MultiplayerManager.singleton.PlayerEndsTurn(currentPlayer.photonId);
			//	}
			//}

			//if(currentState != null)
			//	currentState.Tick(Time.deltaTime);
		}

		public void SetCurrentPhase(Phase p)
		{
			currentPhase = p;
		}

		//public int GetNextPlayerID()
		//{
		//	int r = turnIndex;

		//	r++;
		//	if (r > turns.Length-1)
		//	{
		//		r = 0;
		//	}

		//	return turns[r].player.photonId;
		//}

		//int GetPlayerTurnIndex(int photonID)
		//{
		//	for (int i = 0; i < turns.Length; i++)
		//	{
		//		if (turns[i].player.photonId == photonID)
		//			return i;
		//	}

		//	return -1;
		//}

		//public void ChangeCurrentTurn(int photonId)
		//{
		//	turnIndex = GetPlayerTurnIndex(photonId);
		//	currentPlayer = turns[turnIndex].player;
		//	turns[turnIndex].OnTurnStart();
		//	turnText.value = turns[turnIndex].player.username;
		//	onTurnChanged.Raise();
		//}

		public void SetState(State state)
		{
			currentState = state;
		}

		public void EndCurrentPhase()
		{
			if (currentPhase != null)
			{
//				MultiplayerManager.singleton.PlayerEndsPhase(localPlayer.photonId);
			}
		}

		public void PutCardToGraveyard(CardInstance c)
		{
			c.owner.CardToGraveyard(c);
			graveyardCards.Add(c);
			c.transform.SetParent(graveyardVariable.value);
			Vector3 p = Vector3.zero;
			p.x -= graveyardCards.Count * 5;
			p.z = graveyardCards.Count * 5;
			c.transform.localPosition = p;
			c.transform.localRotation = Quaternion.identity;
			c.transform.localScale = Vector3.one;
			
		}

		public void LocalPlayerEndsBattleResolve()
		{
			//Debug.Log("LocalPlayerEndsBattleResolve");
			//turns[turnIndex].EndCurrentPhase();
		}
	}
}
