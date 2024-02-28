using StaticData;

namespace Infrastructure.Services.StaticData
{
	public interface IStaticDataService
	{
		RotatorStaticData ForRotator { get; }
		TimerStaticData ForTimer { get; }
		void  Load();
	}
}