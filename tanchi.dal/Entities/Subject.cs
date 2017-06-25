using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace tanchi.dal.Entities
{
    public class Subject
    {
        [Key]
        public Guid Id { get; set; }

        public string SubjectName { get; set; }

        public string SubjectDescription { get; set; }
    }
}
