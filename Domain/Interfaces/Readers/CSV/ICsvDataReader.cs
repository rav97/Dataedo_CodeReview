using System.Data;
using System.IO;

namespace Domain.Interfaces.Readers.CSV
{
    public interface ICsvDataReader
    {
        DataTable LoadCsvStreamToDataTable(Stream stream, char separator, bool firstLineContainsHeaders);
    }
}
