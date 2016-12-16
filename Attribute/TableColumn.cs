using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseLib.Attribute
{
    public class TableColumn : System.Attribute
    {
        /// <summary>
        /// DB Column Name
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// DB data type
        /// </summary>
        public Type DataType
        { get; set; }
    }
}
