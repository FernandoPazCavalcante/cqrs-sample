using LiteDB;
using Microsoft.Extensions.Options;

namespace SimpleCQRSApi.Infrastructure.Contexts;

public class LiteDbContext
{
    public LiteDatabase Database { get; }

    public LiteDbContext()
    {
        Database = new LiteDatabase("Data/LiteDB/CqrsLiteDb.db");
    }
}