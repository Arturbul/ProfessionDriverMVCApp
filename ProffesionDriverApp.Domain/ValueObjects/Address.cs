namespace ProfessionDriverApp.Domain.ValueObjects
{
    public class Address : IEquatable<Address>
    {
        public string City { get; set; } = "";
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

        private Address() { }

        public Address(string street, string city, string postalCode, string country)
        {
            Street = street ?? throw new ArgumentNullException(nameof(street));
            City = city ?? throw new ArgumentNullException(nameof(city));
            PostalCode = postalCode ?? throw new ArgumentNullException(nameof(postalCode));
            Country = country ?? throw new ArgumentNullException(nameof(country));
        }

        // Niemutowalność - brak setterów, nowe adresy muszą być tworzone za każdym razem, gdy coś się zmienia
        public override bool Equals(object? obj) // nadal dopuszczamy null, aby była zgodność z metodą Object
        {
            if (obj is null) return false; // jeśli obj jest null, zwracamy false
            if (ReferenceEquals(this, obj)) return true; // porównanie referencji
            if (obj.GetType() != GetType()) return false; // porównanie typów

            var other = (Address)obj;
            return Street == other.Street &&
                   City == other.City &&
                   PostalCode == other.PostalCode &&
                   Country == other.Country; // porównanie właściwości
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Street, City, PostalCode, Country);
        }

        public bool Equals(Address? other)
        {
            return Equals((object?)other);
        }
    }
}
