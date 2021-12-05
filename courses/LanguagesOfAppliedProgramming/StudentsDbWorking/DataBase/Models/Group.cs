using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }

        public Group()
        {
            
        }

        public Group(int id, string name, ICollection<Student> students)
        {
            Id = id;
            Name = name;
            Students = students;
        }
    }
}
