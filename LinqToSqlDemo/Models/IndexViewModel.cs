using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqToSqlDemo.Data;

namespace LinqToSqlDemo.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Person> People { get; set; }
        public string Message { get; set; }
    }
}