using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Models.v1
{
    public class OrderModel
    {
        [Required]
        public Guid CustomerGuid { get; set; }

        [Required]
        public string CustomerFullName { get; set; }
    }
}
