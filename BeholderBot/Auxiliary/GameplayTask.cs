namespace BeholderBot
{
	internal abstract class GameplayTask
	{
		public uint ExcecutionFrequencyDivider = 11;
		public abstract void Execute();
	}
}