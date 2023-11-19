using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaeyApp
{
    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public DateTime DateOfCreation { get; set; }

        public Task(string taskName, DateTime dateOfCreation)
        {
            this.TaskName = taskName;
            this.DateOfCreation = dateOfCreation;
        }

    }
}
