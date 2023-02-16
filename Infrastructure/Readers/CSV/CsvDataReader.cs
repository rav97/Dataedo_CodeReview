using System.Data;
using System.IO;
using Domain.Interfaces.Readers.CSV;

namespace Infrastructure.Readers.CSV
{
    public class CsvDataReader : ICsvDataReader
    {
        public DataTable LoadCsvStreamToDataTable(Stream stream, char separator, bool firstLineContainsHeaders)
        {
            DataTable dt = new DataTable();
            using (var stramReader = new StreamReader(stream))
            {
                string line = string.Empty;
                if (firstLineContainsHeaders)
                {
                    line = stramReader.ReadLine();
                    var headers = line.Split(separator);
                    foreach (var h in headers)
                        dt.Columns.Add(h.Trim());
                }
                else
                {
                    line = stramReader.ReadLine();
                    var elements = line.Split(separator);
                    for (int i = 0; i < elements.Length; i++)
                        dt.Columns.Add($"Column{i + 1}");

                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < elements.Length; i++)
                        dr[i] = elements[i];

                    dt.Rows.Add(dr);
                }
                while ((line = stramReader.ReadLine()) != null)
                {
                    var elements = line.Split(separator);

                    if (elements.Length == dt.Columns.Count)
                    {
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < dt.Columns.Count; i++)
                            dr[i] = elements[i];

                        dt.Rows.Add(dr);
                    }
                }
            }
            dt.AcceptChanges();
            return dt;
        }
    }
}
