﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Management_Entities.DataTransferObjects
{
    public class CustomerCreationDto
    {
        public string CustomerName { get; set; }
        public string CustomerMail { get; set; }
        public string CustomerContact { get; set; }
        public Int32 CustomerTypeId { get; set; }
    }
}
