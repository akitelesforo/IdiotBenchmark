# IdiotBenchmark

[![.NET](https://github.com/akitelesforo/IdiotBenchmark/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/akitelesforo/IdiotBenchmark/actions/workflows/dotnet.yml)

Benchmark for personal use

1. We use Allman style braces

**Bad:**

```csharp
public bool IsShopOpen(string day, int amount) {
    // some logic
}
```

**Good:**

```csharp
public bool IsShopOpen(string day, int amount)
{
    // some logic
}
```

2. We use four spaces of indentation (no tabs)

**Bad:**

```csharp
public bool IsShopOpen(string day, int amount) 
{
____// some logic
}
```

**Good:**

```csharp
public bool IsShopOpen(string day, int amount)
{
....// some logic
}
```

3. We use _camelCase for internal and private fields and use readonly where possible. Prefix internal and private instance fields with _

**Bad:**

```csharp
public class Employee
{
    private IAssetService assetService;
    private IMapper mapper;
}
```

**Good:**

```csharp
public class Employee
{
    private readonly IAssetService _assetService;
    private readonly IMapper _mapper;
}
```

4. We avoid this. unless absolutely necessary

**Bad:**

```csharp
public class Employee
{
    private string _alias;
    private string _name;

    public Employee(string name, string alias)
    {
        this._name = name;
        this._alias = alias;
    }
}
```

**Good:**

```csharp
public class Employee
{
    private string _alias;
    private string _name;

    public Employee(string name, string alias)
    {
        _name = name;
        _alias = alias;
    }
}
```

5. We always specify the visibility, even if it's the default (e.g. private string _foo not string _foo). Visibility should be the first modifier

**Bad:**

```csharp
public class Employee
{
    string _alias;
    string _name;

    public Employee(string name, string alias)
    {
        _name = name;
        _alias = alias;
    }
}
```

**Good:**

```csharp
public class Employee
{
    private string _alias;
    private string _name;

    public Employee(string name, string alias)
    {
        _name = name;
        _alias = alias;
    }
}
```

6.

**Bad:**

```csharp
using Newtonsoft.Json.Linq;
using Polly;
using Polly.Extensions.Http;
using System.Net;
using System.Text;
using System.Web.Http;

namespace UL.Coding

public class Employee
{
    ...
}
```

**Good:**

```csharp
using System.Net;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using Polly;
using Polly.Extensions.Http;

namespace UL.Coding

public class Employee
{
    ...
}
```


7.

**Bad:**

```csharp
public class Employee
{
    public Employee()
    {
        ...
    }
    
    
    public async Task<bool> Update()
    {
        ...
    }
}
```

**Good:**

```csharp
public class Employee
{
    public Employee()
    {
        ...
    }    
    
    public async Task<bool> Update()
    {
        ...
    }
}
```


10.

**Bad:**

```csharp
var stream = OpenStandardInput();
// ...

FileStream stream;
// ...
// ...
stream = new(...);
```

**Good:**

```csharp
var stream = new FileStream(...);
// ...
FileStream stream = new(...);
```


11.

**Bad:**

```csharp
Int32 a = 1;
Int32.Parse(x);
String.IsNullOrEmpty(s);
```

**Good:**

```csharp
int a = 1;
int.Parse(x);
string.IsNullOrEmpty(s);
```

12.

**Bad:**

```csharp
var employeephone;

public double calculateSalary(int workingdays, int workinghours)
{
    // some logic
}
```

**Good:**

```csharp
var employeephone;

public double CalculateSalary(int workingdays, int workinghours)
{
    // some logic
}
```

18.

**Bad:**

```csharp
if (source == null) throw new ArgumentNullException("source");
```

**Good:**

```csharp
if (source == null)
    throw new ArgumentNullException("source");
```
