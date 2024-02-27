using Data;

namespace Infrastructure.Services.PersistentProgress
{
	public interface ISavedProgressUpdater
	{
		void UpdateProgress(Progress progress);
	}
}