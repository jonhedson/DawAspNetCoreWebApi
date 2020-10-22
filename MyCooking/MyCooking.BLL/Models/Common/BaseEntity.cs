using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCooking.BLL.Models.Common

{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
