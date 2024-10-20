using EventManagementSystem.Models;
using System;
using System.Collections.Generic;

namespace EventManagementSystem.Controllers
{
    public class MenuController
    {
        private readonly EventManager _eventManager; // deklariert ein privates, schreibgeschütztes Feld, das eine Instanz von EventManager hält. Das bedeutet, dass _eventManager nur im Konstruktor der MenuController-Klasse zugewiesen werden kann und danach nicht mehr verändert werden kann
        private readonly List<Event> _events; // Liste speichert alle Events, die im System erstellt werden

        // Konstruktor
        public MenuController(EventManager eventManager)
        {
            _eventManager = eventManager;
            _events = new List<Event>(); // Initialisiert die _events-Liste als neue leere Liste von Events
        }

        // Startet das Menü
        public void StartMenu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("==== Event Management System ====");
                Console.WriteLine("1. Add New Event");
                Console.WriteLine("2. Add Participant to Event");
                Console.WriteLine("3. Show All Events");
                Console.WriteLine("4. Exit Program");
                Console.Write("Please choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNewEvent();
                        break;
                    case "2":
                        AddParticipantToEvent();
                        break;
                    case "3":
                        ShowAllEvents();
                        break;
                    case "4":
                        running = false;
                        Console.WriteLine("Program will be terminated...");
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        // Methode zum Hinzufügen eines neuen Events
        private void AddNewEvent()
        {
            Console.Clear();
            Console.WriteLine("==== Add New Event ====");

            Console.Write("Event Name: ");
            string eventName = Console.ReadLine();

            Console.WriteLine("Event Description: ");
            string eventDescription = Console.ReadLine();

            Console.Write("Event Date (yyyy-mm-dd): ");
            DateTime eventDate;
            while (!DateTime.TryParse(Console.ReadLine(), out eventDate))
            {
                Console.WriteLine("Invalid date. Please enter in the format yyyy-mm-dd.");
            }

            Console.Write("Event Location: ");
            string eventLocation = Console.ReadLine();

            Event newEvent = new Event(eventName, eventDate, eventDescription, eventLocation);
            _eventManager.AddEvent(newEvent);
            _events.Add(newEvent);

            Console.WriteLine($"The event '{eventName}' has been successfully added.");
        }

        // Methode zum Hinzufügen eines Teilnehmers zu einem Event
        private void AddParticipantToEvent()
        {
            Console.Clear();
            Console.WriteLine("==== Add Participant to Event ====");

            if (_events.Count == 0)
            {
                Console.WriteLine("There are no available events. Please add an event first.");
                return;
            }

            // Liste der Events anzeigen
            Console.WriteLine("Available Events:");
            for (int i = 0; i < _events.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_events[i].Name} - {_events[i].Date.ToShortDateString()} - {_events[i].Location}");
            }

            Console.Write("Select an event (number): ");
            int eventIndex;
            while (!int.TryParse(Console.ReadLine(), out eventIndex) || eventIndex < 1 || eventIndex > _events.Count)
            {
                Console.WriteLine("Invalid input. Please enter a valid event number.");
            }

            Event selectedEvent = _events[eventIndex - 1];

            // Teilnehmerdetails erfassen
            Console.Write("Participant Name: ");
            string participantName = Console.ReadLine();

            Console.Write("Participant Email: ");
            string participantEmail = Console.ReadLine();

            Console.Write("Participant Phone Number: ");
            string participantPhoneNumber = Console.ReadLine();

            Console.Write("Participant Address: ");
            string participantAddress = Console.ReadLine();

            Console.Write("Participant City: ");
            string participantCity = Console.ReadLine();

            Console.Write("Participant Postal Code: ");
            string participantPostalCode = Console.ReadLine();

            // Erstelle den neuen Teilnehmer mit allen Details
            Participant newParticipant = new Participant(1, participantName, participantEmail, participantPhoneNumber, participantAddress, participantCity, participantPostalCode);

            // Teilnehmer zum Event hinzufügen
            _eventManager.AddParticipant(selectedEvent, newParticipant);

            Console.WriteLine($"Participant '{participantName}' has been successfully added to event '{selectedEvent.Name}'.");
        }

        // Methode zum Anzeigen aller Events
        private void ShowAllEvents()
        {
            Console.Clear();
            Console.WriteLine("==== All Events ====");

            if (_events.Count == 0)
            {
                Console.WriteLine("No events available.");
                return;
            }

            foreach (var e in _events)
            {
                Console.WriteLine($"{e.Name} - {e.Date.ToShortDateString()} - {e.Location}"); // gibt das Datum in einem kurzen, standardisierten Format zurück
            }
        }
    }
}
