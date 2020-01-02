using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Services
{
    public class Kitten
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
