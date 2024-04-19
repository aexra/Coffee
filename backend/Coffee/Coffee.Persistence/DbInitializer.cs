using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Persistence;
public class DbInitializer
{
    public static void Initialize(CoffeeDbContext context)
    {
        context.Database.EnsureCreated();
    }
}
