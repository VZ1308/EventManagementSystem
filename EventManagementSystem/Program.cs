using EventManagementSystem.Controllers;
using EventManagementSystem.Services;
using System;

namespace EventManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Erstelle einen EmailNotifier
            EmailNotifier emailNotifier = new EmailNotifier();

            // Erstelle den EventManager mit dem EmailNotifier, stellt sicher, dass der EventManager in der Lage ist, den EmailNotifier zu verwenden,
            // um Benachrichtigungen zu senden, wenn ein Teilnehmer zu einem Event hinzugefügt wird
            EventManager eventManager = new EventManager(emailNotifier);

            // Teilnehmerhinzufügungs-Event mit einer Lambda Expression verknüpfen
            eventManager.ParticipantAdded += (sender, participant) => { // +=-Operator wird verwendet, um einen neuen Event-Handler zu einem Ereignis hinzuzufügen
                Console.WriteLine($"Neue Benachrichtigung: {participant.Name} wurde registriert.");
            };

            // Erstelle den Menücontroller und starte das Menü, damit man Events und Teilnehmer hinzufuegen kann
            MenuController menuController = new MenuController(eventManager);
            
            menuController.StartMenu();
        }
    }
}
