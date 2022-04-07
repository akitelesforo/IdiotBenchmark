namespace IdiotBenchmark.Mapper.PerformanceTest
{
    public enum AddressType
    {
        House
    }
    
    public class Address
    {
        private static readonly Random Random = new();

        public int Id { get; init; }
        public string? Street { get; init; }
        public string?City { get; init; }
        public string? Country { get; init; }
        public AddressType AddressType { get; private init; }

        public Address Create()
        {
            var a = new Address
            {
                Id = GetRandomNumber(),
                Street = $"Street {GetRandomNumber()}",
                City = $"City {GetRandomNumber()}",
                Country = $"USA {GetRandomNumber()}",
                AddressType = AddressType.House
            };
            return a;
        }
        private static int GetRandomNumber()
        {
            return Random.Next(100);
        }
    }

    public class AddressDto
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public AddressType AddressType { get; set; } = AddressType.House;
    }

    public class Customer
    {
        public static readonly Random Random = new Random();
        public int Id { get; set; }
        public string? Name { get; set; }
        public Address? Address { get; set; }
        public Address? HomeAddress { get; set; }
        public Address[]? AddressList { get; set; }
        public IEnumerable<Address>? WorkAddressList { get; set; }

        public Customer Create()
        {
            var customer = new Customer
            {
                Id = 1,
                Name = "Timucin Kivanc " + GetRandomNumber(),
                Address = new Address()
                {
                    City = "Istanbul " + GetRandomNumber(),
                    Country = "Turkey " + GetRandomNumber(),
                    Id = 1,
                    Street = "Istiklal cad. " + GetRandomNumber(),
                },
                HomeAddress = new Address()
                {
                    City = "Istanbul " + GetRandomNumber(),
                    Country = "Turkey " + GetRandomNumber(),
                    Id = 2,
                    Street = "Istiklal cad. " + GetRandomNumber(),
                },
                WorkAddressList = new Address[]
                {
                    new()
                    {
                        City = "Istanbul " + GetRandomNumber(),
                        Country = "Turkey " + GetRandomNumber(),
                        Id = 5,
                        Street = "Istiklal cad. " + GetRandomNumber(),
                    },
                    new()
                    {
                        City = "Izmir " + GetRandomNumber(),
                        Country = "Turkey " + GetRandomNumber(),
                        Id = 6,
                        Street = "Konak " + GetRandomNumber(),
                    }
                },
                AddressList = new Address[]
                {
                    new()
                    {
                        City = "Istanbul " + GetRandomNumber(),
                        Country = "Turkey " + GetRandomNumber(),
                        Id = 3,
                        Street = "Istiklal cad. " + GetRandomNumber(),
                    },
                    new()
                    {
                        City = "Izmir " + GetRandomNumber(),
                        Country = "Turkey " + GetRandomNumber(),
                        Id = 4,
                        Street = "Konak " + GetRandomNumber(),
                    }
                }
            };

            return customer;
        }
        private static Int32 GetRandomNumber()
        {
            return Random.Next(100);
        }
    }

    public class CustomerDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Address? Address { get; set; }
        public AddressDto? HomeAddress { get; set; }
        public AddressDto[]? AddressList { get; set; }
        public List<AddressDto>? WorkAddressList { get; set; }
    }

}
