using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApp
{
    public class Note
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string DateOfCreation { get; set; }

        public Note(string taskName, string dateOfCreation)
        {
            this.TaskName = taskName;
            this.DateOfCreation = dateOfCreation;
        }
    }
}
