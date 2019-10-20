using System;
using System.ComponentModel.DataAnnotations;

namespace DL.DomainModels.Base
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
