using System;
using System.Collections.Generic;

namespace EventManagementSystem.Models
{
    /// <summary>
    /// Repräsentiert ein Event mit einem Namen, Datum, Beschreibung, Standort und einer Teilnehmerliste.
    /// </summary>
    public class Event
    {
        private string _name;
        private DateTime _date;
        private string _description;
        private string _location;

        /// <summary>
        /// Der Name des Events.
        /// </summary>
        /// <exception cref="ArgumentException">Wird ausgelöst, wenn der Name leer oder null ist.</exception>
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name darf nicht leer sein.");
                }
                _name = value;
            }
        }

        /// <summary>
        /// Das Datum des Events.
        /// </summary>
        /// <exception cref="ArgumentException">Wird ausgelöst, wenn das Datum der Standardwert ist oder vor dem heutigen Datum liegt.</exception>
        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (value == default(DateTime))
                {
                    throw new ArgumentException("Datum darf nicht der Standardwert sein.");
                }
                else if (value < DateTime.Today)
                {
                    throw new ArgumentException("Datum darf nicht vor heutigem Datum sein.");
                }
                _date = value;
            }
        }

        /// <summary>
        /// Die Beschreibung des Events.
        /// </summary>
        /// <exception cref="ArgumentException">Wird ausgelöst, wenn die Beschreibung leer oder null ist.</exception>
        public string Description
        {
            get { return _description; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Die Beschreibung darf nicht leer sein.");
                }
                _description = value;
            }
        }

        /// <summary>
        /// Der Ort (Location) des Events.
        /// </summary>
        /// <exception cref="ArgumentException">Wird ausgelöst, wenn der Ort leer oder null ist.</exception>
        public string Location
        {
            get { return _location; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Die Location darf nicht leer sein.");
                }
                _location = value;
            }
        }

        /// <summary>
        /// Überprüft, ob alle Event-Eigenschaften gültige Werte haben.
        /// </summary>
        /// <returns><c>true</c>, wenn alle Werte gültig sind; andernfalls <c>false</c>.</returns>
        public bool AreValuesValid()
        {
            try
            {
                // Hier wird versucht, alle Getter-Eigenschaften aufzurufen, um die Validität zu prüfen
                string testName = _name;
                DateTime testDate = _date;
                string testDescription = _description;
                string testLocation = _location;

                return true; // Wenn keine Ausnahme geworfen wird, sind alle Werte gültig
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ungültige Eingabe: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Formatfehler: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ein unerwarteter Fehler ist aufgetreten: {ex.Message}");
            }

            return false; // Bei einer Ausnahme werden die Werte als ungültig betrachtet
        }

        /// <summary>
        /// Die Liste der Teilnehmer, die an dem Event teilnehmen.
        /// </summary>
        public List<Participant> Participants { get; set; }

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="Event"/>-Klasse.
        /// </summary>
        /// <param name="name">Der Name des Events.</param>
        /// <param name="date">Das Datum des Events.</param>
        /// <param name="description">Die Beschreibung des Events.</param>
        /// <param name="location">Der Ort, an dem das Event stattfindet.</param>
        /// <exception cref="ArgumentException">Wird ausgelöst, wenn einer der Parameter ungültig ist.</exception>
        public Event(string name, DateTime date, string description, string location)
        {
            Name = name; // Setter wird verwendet, damit die Validierung funktioniert
            Date = date;
            Description = description;
            Location = location;

            Participants = new List<Participant>(); // Initialisiere die Teilnehmerliste (Jedes Event hat eigene Teilnehmerliste)
        }
    }
}
