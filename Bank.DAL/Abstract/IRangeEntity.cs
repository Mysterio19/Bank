using System;

namespace Bank.DAL.Abstract
{
    public interface IRangeEntity
    {
        DateTime ExpDate { get; set; }
        DateTime CreationDate { get; set; }
    }
}