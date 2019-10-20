using System;

namespace BL.BusinessModels.Base
{
    public interface IBaseModel
    {
        int Id { get; set; }

        DateTime CreateDate { get; set; }

        DateTime? UpdateDate { get; set; }
    }
}
