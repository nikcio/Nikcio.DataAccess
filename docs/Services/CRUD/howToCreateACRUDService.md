# How to create a CRUD repository

```csharp
using Nikcio.DataAccess.Services;
using Nikcio.DataAccess.Services.Crud;
using Microsoft.Extensions.Logging;

namespace MyNamespace.Services {
    public class MyService : CrudServiceBase<MyModel, IMyRepository>, IMyService {
        public MyService(IMyRepository repository, ILogger<ServiceBase<IMyRepository>> logger) : base(repository, logger) {
        }
    }
}

```

```csharp
using Nikcio.DataAccess.Services.Crud;

namespace MyNamespace.Services {
    public interface IMyService : ICrudServiceBase<MyModel, IMyRepository> {
    }
}
```