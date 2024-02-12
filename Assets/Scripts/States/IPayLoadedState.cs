namespace States
{
	public interface IPayLoadedState<TPayLoad> : IExitableState
	{
		void Enter(TPayLoad payLoad);
	}
}