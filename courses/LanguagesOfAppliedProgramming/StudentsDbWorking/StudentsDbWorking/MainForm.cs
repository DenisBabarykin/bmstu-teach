using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBase;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentsDbWorking
{
    public partial class MainForm : Form
    {
        private StudentsContext DbContext { get; set; }
        private TextBox _tbx = new TextBox();

        public MainForm()
        {
            InitializeComponent();
            this.Width = 800;
            this.Height = 800;
            _tbx.Parent = this;
            _tbx.Width = 600;
            _tbx.Height = 600;
            _tbx.Visible = true;
            _tbx.Multiline = true;
        }

        public MainForm(StudentsContext dbContext)
            : this()
        {
            DbContext = dbContext;
            InitDb();
            AddStudents();
            MoveStudent();
            ShowStudentsGroup2();
            ShowStudentsGroup3();
        }

        private void MoveStudent()
        {
            var groupIdDst = DbContext.Groups.First(g => g.Name == "Group3").Id;

            var student = DbContext.Students
                .Include(s => s.Group)
                .Where(s => s.Group.Name == "Group2")
                .OrderBy(s => s.Name)
                .First();

            student.GroupId = groupIdDst;
            DbContext.SaveChanges();
        }

        private void AddStudents()
        {
            var groupId = DbContext.Groups.First(g => g.Name == "Group2").Id;
            var students = new List<Student>()
            {
                new Student()
                {
                    Name = "New Vasya",
                    GroupId = groupId
                },
                new Student()
                {
                    Name = "New Petya",
                    GroupId = groupId
                }
            };
            DbContext.Students.AddRange(students);
            DbContext.SaveChanges();
        }

        private void ShowStudentsGroup2()
        {
            var students = DbContext.Students
                .Include(s => s.Group)
                .Where(s => s.Group.Name == "Group2")
                .ToList();

            foreach (var student in students)
            {
                _tbx.Text += student.ToString();
            }
        }

        private void ShowStudentsGroup3()
        {
            var students = DbContext.Groups
                .Include(g => g.Students)
                .First(g => g.Name == "Group3")
                .Students;

            foreach (var student in students)
            {
                _tbx.Text += student.ToString();
            }
        }

        private void InitDb()
        {
            DbContext.Students.RemoveRange(DbContext.Students);
            DbContext.Groups.RemoveRange(DbContext.Groups);

            var group2 = new Group()
            {
                Name = "Group2",
                Students = new List<Student>()
                {
                    new Student()
                    {
                        Name = "Masha",
                    },
                    new Student()
                    {
                        Name = "Katya",
                    }
                },
            };
            var group3 = new Group()
            {
                Name = "Group3",
                Students = new List<Student>()
                {
                    new Student()
                    {
                        Name = "Olya",
                    },
                    new Student()
                    {
                        Name = "Vanya",
                    }
                },
            };
            var group4 = new Group()
            {

                Name = "Group 4",
                Students = new List<Student>()
                {
                    new Student()
                    {
                        Name = "Vasya",
                    },
                    new Student()
                    {
                        Name = "Petya",
                    }
                },

            };

            DbContext.Groups.Add(group4);
            DbContext.Groups.Add(group2);
            DbContext.Groups.Add(group3);
            DbContext.SaveChanges();
        }
    }
}
