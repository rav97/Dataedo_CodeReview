using Application.Managers.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Domain.Interfaces.Readers.CSV;
using Infrastructure.Readers.CSV;
using Domain.SourceModels;
using Infrastructure.Mappers;
using Domain.Interfaces.Mappers;
using Application.Models;
using Application.Mappers.Interfaces;
using Application.Mappers;

namespace Application.Managers
{
    public class DatabaseCsvManager : ICsvManager
    {
        private bool _firstLineContainsHeaders;
        private char _separator;
        private string _filePath;

        public DatabaseCsvManager(string filePath, char separator = ';', bool firstLineContainsHeaders = true)
        {
            this._filePath = filePath;
            this._separator = separator;
            this._firstLineContainsHeaders = firstLineContainsHeaders;
        }

        public void ImportAndPrint()
        {
            //Load CSV file into DataTable
            DataTable csvDataTable;
            using (var fs = new FileStream(_filePath, FileMode.Open))
            {
                ICsvDataReader reader = new CsvDataReader();
                csvDataTable = reader.LoadCsvStreamToDataTable(fs, separator: _separator, firstLineContainsHeaders: _firstLineContainsHeaders);
            }

            //Convert DataTable into Source model
            ICollection<DatabaseItemCsvModel> csvDataList;
            IDataTableMapper<DatabaseItemCsvModel> tableToCsv = new DatabaseItemCsvMapper();
            csvDataList = tableToCsv.MappFromDatatable(csvDataTable);

            //Convert DTO model into DTO model
            ICollection<DatabaseItem> databaseItems;
            ICollectionMapper<DatabaseItemCsvModel, DatabaseItem> csvToitem = new DatabaseItemListMapper();
            databaseItems = csvToitem.MappCollection(csvDataList);

            //Convert DTO model into detailed model
            ICollection<DatabaseItemInfo> databaseItemInfos;
            ICollectionMapper<DatabaseItem, DatabaseItemInfo> itemToInfo = new DatabaseItemListMapper();
            databaseItemInfos = itemToInfo.MappCollection(databaseItems);

            //Display on console
            IConsoleDisplayer<ICollection<DatabaseItemInfo>> consoleDisplayer = new DatabaseItemsInfoDisplayer();
            consoleDisplayer.DisplayOnConsole(databaseItemInfos);
        }
    }
}
