using System;

namespace Bank.DAL.Models
{
    public class Entity
    {
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case null:
                    return false;
                case Entity castObj:
                    return castObj.Id == Id;
                default:
                    return false;
            }
        }

        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdateAt { get; set; }

        public bool IsDeleted { get; set; }
    }
}