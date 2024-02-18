namespace Infrastructure.Services
{
	public interface IRandomService : IService
	{
		float Next(float min, float max);
	}
}