namespace EventManagementSystem.Interfaces
{
    /// <summary>
    /// Definiert eine Methode zur Benachrichtigung.
    /// </summary>
    public interface IEventNotifier
    {
        /// <summary>
        /// Sendet eine Benachrichtigung über ein Event und einen Teilnehmer.
        /// </summary>
        /// <param name="eventDetails">Details des Events</param>
        /// <param name="participant">Der hinzugefügte Teilnehmer</param>
        void Notify(EventManagementSystem.Models.Event eventDetails, EventManagementSystem.Models.Participant participant);
    }
}
