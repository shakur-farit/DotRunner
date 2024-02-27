using Data;

namespace Infrastructure.Services.PersistentProgress
{
	public interface ISavedProgressReader
	{
		void LoadProgress(Progress progress);
	}
}