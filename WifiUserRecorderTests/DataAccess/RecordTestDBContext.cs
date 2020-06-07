using System;
using Microsoft.EntityFrameworkCore;
using WifiUserRecorder.DataAccess;

namespace WifiUserRecorderTests.DataAccess.Tests
{
    public class RecordTestDBContext : RecordDBContext
    {
        protected override void OnCustomConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
        }
    }
}
