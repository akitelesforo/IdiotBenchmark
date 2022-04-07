using AutoMapper;
using BenchmarkDotNet.Attributes;
using HigLabo.Core;
using IdiotBenchmark.Mapper.PerformanceTest;
using Mapster;
using Nelibur.ObjectMapper;

namespace IdiotBenchMark.Mapper.PerformanceTest;

[Config(typeof(BenchmarkConfig))]
[RankColumn]
public class MapperPerformanceTest
{
    private const int ExecuteCount = 500;

    private readonly IMapper _autoMapper;
    private readonly Customer _customer;
    private readonly Address _address;

    public MapperPerformanceTest()
    {
        var autoMapperConfiguration = new MapperConfiguration(config =>
        {
            config.CreateMap<Customer, Customer>();
            config.CreateMap<Customer, CustomerDto>();
            config.CreateMap<Address, AddressDto>();
        });
        
        _autoMapper = autoMapperConfiguration.CreateMapper();

        TinyMapper.Bind<Address, Address>();
        TinyMapper.Bind<Address, AddressDto>();
        TinyMapper.Bind<Customer, Customer>();
        TinyMapper.Bind<Customer, CustomerDto>();
        
        _customer = _customer?.Create() ?? new Customer();
        _address = _address?.Create() ?? new Address();
    }

    [Benchmark(Baseline = true)]
    public void HandwriteMapper_AddressDto()
    {
        var address = _address.Create();
        for (var i = 0; i < ExecuteCount; i++)
        {
            MapAddress(address, new AddressDto());
        }
    }

    private void MapAddress(Address address, AddressDto addressDto)
    {
        addressDto.Id = address.Id;
        addressDto.City = address.City;
        addressDto.Country = address.Country;
        addressDto.AddressType = address.AddressType;
    }

    [Benchmark]
    public void HigLaboObjectMapper_AddressDTO()
    {
        for (var i = 0; i < ExecuteCount; i++)
        {
            ObjectMapper.Default.Map(_address, new AddressDto());
        }
    }
    
    [Benchmark]
    public void Mapster_AddressDTO()
    {
        for (var i = 0; i < ExecuteCount; i++)
        {
            _address.Adapt(new AddressDto());
        }
    }
    
    [Benchmark]
    public void AutoMapper_AddressDTO()
    {
        for (var i = 0; i < ExecuteCount; i++)
        {
            _autoMapper.Map<AddressDto>(_address);
        }
    }
    
    [Benchmark]
    public void TinyMapper_AddressDTO()
    {
        for (var i = 0; i < ExecuteCount; i++)
        {
            TinyMapper.Map<AddressDto>(_address);
        }
    }
    //
    // [Benchmark]
    // public void HigLaboObjectMapper_Customer()
    // {
    //     for (var i = 0; i < ExecuteCount; i++)
    //     {
    //         ObjectMapper.Default.Map(_customer, new Customer());
    //     }
    // }
    //
    // [Benchmark]
    // public void Mapster_Customer()
    // {
    //     for (var i = 0; i < ExecuteCount; i++)
    //     {
    //         _customer.Adapt(new Customer());
    //     }
    // }
    //
    // [Benchmark]
    // public void AutoMapper_Customer()
    // {
    //     for (var i = 0; i < ExecuteCount; i++)
    //     {
    //         _autoMapper.Map<Customer>(_customer);
    //     }
    // }
    //
    // [Benchmark]
    // public void TinyMapper_Customer()
    // {
    //     var customer = _customer.Create();
    //     var count = ExecuteCount;
    //
    //     for (var i = 0; i < count; i++)
    //     {
    //         TinyMapper.Map<Customer>(customer);
    //     }
    // }
    //
    // [Benchmark]
    // public void HandwriteMapper_Customer_CustomerDTO()
    // {
    //     var customer = _customer.Create();
    //     for (var i = 0; i < ExecuteCount; i++)
    //     {
    //         MapCustomer(customer, new CustomerDto());
    //     }
    // }
    //
    // private void MapCustomer(Customer customer, CustomerDto customerDto)
    // {
    //     customerDto.Id = customer.Id;
    //     customerDto.Name = customer.Name;
    //     if (customer.Address != null)
    //         customerDto.Address = new Address
    //         {
    //             Id = customer.Address.Id,
    //             Street = customer.Address.Street,
    //             City = customer.Address.City,
    //             Country = customer.Address.Country
    //         };
    //     if (customer.AddressList != null)
    //     {
    //         customerDto.AddressList = new AddressDto[customer.AddressList.Length];
    //         for (int aIndex = 0; aIndex < customer.AddressList.Length; aIndex++)
    //         {
    //             customerDto.AddressList[aIndex] = new AddressDto
    //             {
    //                 Id = customer.AddressList[aIndex].Id,
    //                 City = customer.AddressList[aIndex].City,
    //                 Country = customer.AddressList[aIndex].Country
    //             };
    //         }
    //     }
    //
    //     customerDto.HomeAddress = new AddressDto();
    //     customerDto.HomeAddress.Id = customerDto.HomeAddress.Id;
    //     customerDto.HomeAddress.City = customerDto.HomeAddress.City;
    //     customerDto.HomeAddress.Country = customerDto.HomeAddress.Country;
    //     
    //     customer.WorkAddressList = new List<Address>();
    //     foreach (var item in customer.WorkAddressList)
    //     {
    //         customerDto.WorkAddressList?.Add(new AddressDto
    //         {
    //             Id = item.Id,
    //             City = item.City,
    //             Country = item.Country,
    //         });
    //     }
    //
    //     foreach (var item in customer.WorkAddressList)
    //     {
    //         customerDto.WorkAddressList?.Add(new AddressDto
    //         {
    //             Id = item.Id,
    //             City = item.City,
    //             Country = item.Country,
    //         });
    //     }
    // }
    //
    // [Benchmark]
    // public void HigLaboObjectMapper_Customer_CustomerDTO()
    // {
    //     for (var i = 0; i < ExecuteCount; i++)
    //     {
    //         ObjectMapper.Default.Map(_customer, new CustomerDto());
    //     }
    // }
    //
    // [Benchmark]
    // public void Mapster_Customer_CustomerDTO()
    // {
    //     for (var i = 0; i < ExecuteCount; i++)
    //     {
    //         _customer.Adapt(new CustomerDto());
    //     }
    // }
    //
    // [Benchmark]
    // public void AutoMapper_Customer_CustomerDTO()
    // {
    //     for (var i = 0; i < ExecuteCount; i++)
    //     {
    //         _autoMapper.Map<CustomerDto>(_customer);
    //     }
    // }

}