namespace PlaneCut
{
	public interface IGameStateMachine
	{
		void ChangeState(IGameState newState);
	}
}