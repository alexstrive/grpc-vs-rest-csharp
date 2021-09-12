
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace GrpcServer
{
 
    public class CovidStatsDatabaseService
    {
        public IEnumerable<CovidStatsEntry> Entries { get; init; }
        
        public CovidStatsDatabaseService()
        {
            using (var reader = new StreamReader("data/covid-europe.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                Entries = csv.GetRecords<CovidStatsEntry>().ToList();
            }
        }
    }

    public class CovidStatsEntry
    {
        public string dateRep { get; set; }
        public byte day { get; set; }
        public byte month { get; set; }
        public uint year { get; set; }
        public uint cases { get; set; }
        public uint deaths { get; set; }
        public string countriesAndTerritories { get; set; }
        public string geoId { get; set; }
        public string countryterritoryCode { get; set; }
        public uint popData2020 { get; set; }
        public string continentExp { get; set; }
    }
}