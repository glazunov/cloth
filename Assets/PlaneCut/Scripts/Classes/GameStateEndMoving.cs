using Zenject;
using UnityEngine.SceneManagement;


namespace PlaneCut
{
	public class GameStateEndMoving : IGameState
	{
		public void Enter()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

	}
}
