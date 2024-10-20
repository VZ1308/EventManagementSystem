using EventManagementSystem.Interfaces;
using EventManagementSystem.Models;
using EventManagementSystem.Services;
using System;
using System.Collections.Generic;

namespace EventManagementSystem.Controllers
{
    /// <summary>
    /// Verwalten von Events und Teilnehmern.
    /// </summary>
    public class EventManager
    {
        // Liste der Events
        private List<Event> events = new List<Event>();

        // Liste der Teilnehmer
        private List<Participant> participants = new List<Participant>();

        // Statische Variable zur Verfolgung der nächsten Teilnehmer-ID
        private static int _nextParticipantId = 1;

        // Delegate für das Hinzufügen von Teilnehmern, delegate ist ein Typ, der auf Methoden verweist, die ein bestimmtes Argumentmuster haben
        public delegate void ParticipantAddedHandler(object sender, Participant participant); //sender = Objekt, das das Ereignis ausgelöst hat

        /// <summary>
        /// Event, das ausgelöst wird, wenn ein Teilnehmer hinzugefügt wird, verwendet obigen delegate
        /// </summary>
        public event ParticipantAddedHandler ParticipantAdded; 

        private IEventNotifier notifier; //wird verwendet, um eine Instanz eines Objekts zu halten, dass das IEventNotifier-Interface implementiert

        /// <summary>
        /// Konstruktor der EventManager-Klasse.
        /// </summary>
        /// <param name="notifier">Notifier für Benachrichtigungen</param>
        public EventManager(IEventNotifier notifier) // Konstruktor akzeptiert ein IEventNotifier-Objekt, das verwendet wird, um Benachrichtigungen zu senden
        {
            this.notifier = notifier; // Hier wird der Parameter notifier, der beim Aufruf des Konstruktors übergeben wurde, der privaten Instanzvariable notifier der Klasse EventManager zugewiesen
        }

        /// <summary>
        /// Fügt ein neues Event hinzu.
        /// </summary>
        /// <param name="eventDetails">Details des Events</param>
        public void AddEvent(Event eventDetails)
        {
            //Eventdetails werden zur privaten events Liste hinzugefügt
            events.Add(eventDetails);
            
            Console.WriteLine($"Event hinzugefügt: {eventDetails.Name}");
        }

        /// <summary>
        /// Fügt einen Teilnehmer zu einem Event hinzu und löst das ParticipantAdded Event aus.
        /// </summary>
        /// <param name="eventDetails">Das Event, dem der Teilnehmer hinzugefügt wird</param>
        /// <param name="participant">Der Teilnehmer, der hinzugefügt wird</param>
        public void AddParticipant(Event eventDetails, Participant participant)
        {
            // Setze die ID für den neuen Teilnehmer
            participant.Id = _nextParticipantId++;

            // Füge den Teilnehmer der Teilnehmerliste hinzu
            participants.Add(participant);

            // Fügt den Teilnehmer zum Event hinzu
            eventDetails.Participants.Add(participant);

            // Teilnehmer hinzugefügt
            Console.WriteLine($"Teilnehmer {participant.Name} wurde dem Event {eventDetails.Name} hinzugefügt.");

            // Event auslösen, bewirkt, dass alle registrierten Methoden, die auf das ParticipantAdded-Event hören, aufgerufen werden und ihnen Informationen über den neu hinzugefügten Teilnehmer übergeben
            ParticipantAdded?.Invoke(this, participant); // this = die Instanz der EventManager-Klasse, die das Event auslöst

            // Benachrichtigung senden, dass  neuer Teilnehmer zu Event hinzugefügt wurde
            notifier.Notify(eventDetails, participant);
        }
    }
}
