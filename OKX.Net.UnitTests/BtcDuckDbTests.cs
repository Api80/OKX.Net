using NUnit.Framework;
using DuckDB.NET.Data;

namespace OKX.Net.UnitTests
{
    [TestFixture]
    public class BtcDuckDbTests
    {
        [Test]
        public void Test()
        {
            // This test verifies that DuckDB can be initialized without throwing TypeInitializationException
            // The fix involves using DuckDB.NET.Data.Full package and setting RuntimeIdentifier in the project file
            
            using var connection = new DuckDBConnection("DataSource=:memory:");
            connection.Open();
            
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT 'BTC-USDT' as symbol, 42000.00 as price";
            
            using var reader = command.ExecuteReader();
            Assert.That(reader.Read(), Is.True);
            Assert.That(reader.GetString(0), Is.EqualTo("BTC-USDT"));
            Assert.That(reader.GetDecimal(1), Is.EqualTo(42000.00m));
        }
    }
}
