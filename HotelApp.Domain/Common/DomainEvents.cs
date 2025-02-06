namespace HotelApp.Domain.Common
{
    public static class DomainEvents
    {
        private static List<IDomainEvent> _events = new();

        public static void Raise(IDomainEvent domainEvent)
        {
            _events.Add(domainEvent);
        }

        public static List<IDomainEvent> GetEvents() => _events;
    }
}
