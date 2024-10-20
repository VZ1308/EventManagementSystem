using EventManagementSystem.Interfaces;
using EventManagementSystem.Models;
using System;

namespace EventManagementSystem.Services
{
    /// <summary>
    /// Implementiert die IEventNotifier Schnittstelle, um Benachrichtigungen per E-Mail zu senden.
    /// </summary>
    public class EmailNotifier : IEventNotifier
    {
        /// <summary>
        /// Sendet eine Benachrichtigung über einen neuen Teilnehmer.
        /// </summary>
        /// <param name="eventDetails">Details des Events</param>
        /// <param name="participant">Der hinzugefügte Teilnehmer</param>
        public void Notify(Event eventDetails, Participant participant)
        {
            // Simuliert das Senden einer E-Mail-Benachrichtigung
            Console.WriteLine($"E-Mail gesendet an {participant.Email}: " +
                $"Teilnehmer {participant.Name} wurde dem Event {eventDetails.Name} hinzugefügt.");
        }
    }
}
