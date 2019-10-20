using System;

namespace DL.DomainModels.Base
{
    public interface IBaseEntity
    {
        int Id { get; set; }

        DateTime CreateDate { get; set; }

        DateTime? UpdateDate { get; set; }
    }
}
