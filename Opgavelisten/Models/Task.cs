using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Opgavelisten.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateCreated { get; set; }
        public int CategoryId { get; set; }
        public string FinishedAssignment { get; set; }
    }
}