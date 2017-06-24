using DAL.Model.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Student : User
    {
        public string LearningPlace { get; set; }

        public double TransactionFeeMultiplier { get; set; }
    }
}
