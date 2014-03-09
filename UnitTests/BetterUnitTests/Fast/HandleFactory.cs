using System;

namespace BetterUnitTests.Fast
{
    public class HandleFactory
    {
        readonly IHandlePersistence HandlePersistence;
        readonly Random Random = new Random();

        public HandleFactory(IHandlePersistence handlePersistence)
        {
            HandlePersistence = handlePersistence;
        }

        public string CreateNewHandle()
        {
            string handle;
            do
            {
                handle = GenerateHandle();
            } while (HandlePersistence.HandleExists(handle));
            HandlePersistence.SaveNewHandle(handle);
            return handle;
        }

       protected virtual string GenerateHandle()
        {
            var handle = string.Empty;
            for (var i = 0; i < 10; i++)
            {
                handle += (char) Random.Next(65, 91);
            }
            return handle;
        }
    }
}