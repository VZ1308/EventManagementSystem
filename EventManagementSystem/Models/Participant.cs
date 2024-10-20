using System;
using System.Text.RegularExpressions;

namespace EventManagementSystem.Models
{
    /// <summary>
    /// Repräsentiert einen Teilnehmer eines Events.
    /// </summary>
    public class Participant
    {
        private int _id;
        private string _name;
        private string _email;
        private string _phoneNumber;
        private string _address;
        private string _city;
        private string _postalCode;

        /// <summary>
        /// Die eindeutige ID des Teilnehmers.
        /// </summary>
        /// <exception cref="ArgumentException">Wird ausgelöst, wenn die ID kleiner oder gleich 0 ist.</exception>
        public int Id
        {
            get { return _id; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Die ID muss eine positive Zahl sein.");
                }
                _id = value;
            }
        }

        /// <summary>
        /// Der Name des Teilnehmers.
        /// </summary>
        /// <exception cref="ArgumentException">Wird ausgelöst, wenn der Name leer oder null ist.</exception>
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Der Name darf nicht leer sein.");
                }
                _name = value;
            }
        }

        /// <summary>
        /// Die E-Mail-Adresse des Teilnehmers.
        /// </summary>
        /// <exception cref="ArgumentException">Wird ausgelöst, wenn die E-Mail-Adresse leer ist oder nicht dem richtigen Format entspricht.</exception>
        public string Email
        {
            get { return _email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Die E-Mail-Adresse darf nicht leer sein.");
                }

                // Einfache Regex-Überprüfung für E-Mail-Adressen
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(value, emailPattern))
                {
                    throw new ArgumentException("Die E-Mail-Adresse ist ungültig.");
                }

                _email = value;
            }
        }

        /// <summary>
        /// Die Telefonnummer des Teilnehmers.
        /// </summary>
        /// <exception cref="ArgumentException">Wird ausgelöst, wenn die Telefonnummer leer ist oder nicht dem internationalen Format entspricht.</exception>
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Die Telefonnummer darf nicht leer sein.");
                }

                // Einfache Regex-Überprüfung für Telefonnummern (internationales Format)
                string phonePattern = @"^\+?[0-9\s]{7,15}$";
                if (!Regex.IsMatch(value, phonePattern))
                {
                    throw new ArgumentException("Die Telefonnummer ist ungültig.");
                }

                _phoneNumber = value;
            }
        }

        /// <summary>
        /// Die Adresse des Teilnehmers.
        /// </summary>
        /// <exception cref="ArgumentException">Wird ausgelöst, wenn die Adresse leer oder null ist.</exception>
        public string Address
        {
            get { return _address; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Die Adresse darf nicht leer sein.");
                }
                _address = value;
            }
        }

        /// <summary>
        /// Die Stadt des Teilnehmers.
        /// </summary>
        /// <exception cref="ArgumentException">Wird ausgelöst, wenn die Stadt leer oder null ist.</exception>
        public string City
        {
            get { return _city; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Die Stadt darf nicht leer sein.");
                }
                _city = value;
            }
        }

        /// <summary>
        /// Die Postleitzahl des Teilnehmers.
        /// </summary>
        /// <exception cref="ArgumentException">Wird ausgelöst, wenn die Postleitzahl leer ist oder nicht dem Format entspricht (5-stellig).</exception>
        public string PostalCode
        {
            get { return _postalCode; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Die Postleitzahl darf nicht leer sein.");
                }

                // Einfache Regex-Überprüfung für Postleitzahlen (deutsches Format 5-stellig)
                string postalCodePattern = @"^\d{5}$";
                if (!Regex.IsMatch(value, postalCodePattern))
                {
                    throw new ArgumentException("Die Postleitzahl ist ungültig.");
                }

                _postalCode = value;
            }
        }

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="Participant"/>-Klasse.
        /// </summary>
        /// <param name="id">Die eindeutige ID des Teilnehmers.</param>
        /// <param name="name">Der Name des Teilnehmers.</param>
        /// <param name="email">Die E-Mail-Adresse des Teilnehmers.</param>
        /// <param name="phoneNumber">Die Telefonnummer des Teilnehmers.</param>
        /// <param name="address">Die Adresse des Teilnehmers.</param>
        /// <param name="city">Die Stadt des Teilnehmers.</param>
        /// <param name="postalCode">Die Postleitzahl des Teilnehmers.</param>
        /// <exception cref="ArgumentException">Wird ausgelöst, wenn eine der Eingaben ungültig ist.</exception>
        public Participant(int id, string name, string email, string phoneNumber, string address, string city, string postalCode)
        {
            Id = id; // Validierung durch Setter
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            City = city;
            PostalCode = postalCode;
        }

        /// <summary>
        /// Gibt eine Zeichenkette zurück, die das Objekt beschreibt.
        /// </summary>
        /// <returns>Die Beschreibung des Teilnehmers.</returns>
        public override string ToString()
        {
            return $"Teilnehmer {Id}: {Name}, E-Mail: {Email}, Telefonnummer: {PhoneNumber}, Adresse: {Address}, {PostalCode} {City}";
        }

        /// <summary>
        /// Überprüft, ob alle Eigenschaften des Teilnehmers gültige Werte haben.
        /// </summary>
        /// <returns><c>true</c>, wenn alle Werte gültig sind; andernfalls <c>false</c>.</returns>
        public bool AreValuesValid()
        {
            try
            {
                // Die Getter aufrufen, um die Validität der Werte zu testen
                int testId = _id;
                string testName = _name;
                string testEmail = _email;
                string testPhoneNumber = _phoneNumber;
                string testAddress = _address;
                string testCity = _city;
                string testPostalCode = _postalCode;

                return true; // Wenn keine Ausnahme geworfen wird, sind alle Werte gültig
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ungültige Eingabe: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ein unerwarteter Fehler ist aufgetreten: {ex.Message}");
            }

            return false; // Bei einer Ausnahme sind die Werte ungültig
        }
    }
}
