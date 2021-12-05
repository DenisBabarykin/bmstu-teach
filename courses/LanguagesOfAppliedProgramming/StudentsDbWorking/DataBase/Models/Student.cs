using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public Student()
        {
            
        }

        public Student(string name, int groupId, Group group, int id = 0)
        {
            Id = id;
            Name = name;
            GroupId = groupId;
            Group = group;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, GroupId: {GroupId}, Name: {Group.Name ?? ""}" + "\r\n";
        }
    }
}
