using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace TestBulankin
{
    [Table(Name = "C#Table")]
    class TableClass
    {
        [Column(Name ="Id", IsPrimaryKey = true, IsDbGenerated = true , DbType = "int NOT NULL")]
        public int Id { get; set; }
        [Column(Name = "Dat", DbType = "date NOT NULL")]
        public DateTime Dat { get; set; }
        [Column(Name = "Organisation", DbType = "NVarChar(50) NOT NULL")]        
        public string Organisation { get; set; }
        [Column(Name = "City", DbType = "NVarChar(50) NOT NULL")]
        public string City { get; set; }
        [Column(Name = "Country", DbType = "NVarChar(50) NOT NULL")]
        public string Country { get; set; }
        [Column(Name = "Manager", DbType = "NVarChar(50) NOT NULL")]
        public string Manager { get; set; }
        [Column(Name = "Quantity", DbType = "decimal(13,2) NOT NULL")]
        public decimal Quantity { get; set; }
        [Column(Name = "Summa", DbType = "decimal(13,2) NOT NULL")]
        public decimal Summa { get; set; }        

    }
}
