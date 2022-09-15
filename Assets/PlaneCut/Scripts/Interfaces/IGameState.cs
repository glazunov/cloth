namespace PlaneCut
{
	public interface IGameState
	{
		void Enter();
		void Execute();
		void Exit();
	}
}
