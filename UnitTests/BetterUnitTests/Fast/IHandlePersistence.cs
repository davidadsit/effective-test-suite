namespace BetterUnitTests.Fast
{
    public interface IHandlePersistence
    {
        bool HandleExists(string handle);
        void SaveNewHandle(string handle);
    }
}