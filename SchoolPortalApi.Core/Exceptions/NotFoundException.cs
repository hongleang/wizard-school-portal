namespace SchoolPortalApi.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string entityName, string id, string? operation)
            : base($"Can't find ${entityName} with an id: " +
                  $"{id} at ${operation}")
        {

        }
    }
}
