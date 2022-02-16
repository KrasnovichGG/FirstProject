using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstProject.models
{
    [Table("Борщ")]
    public class ProjectModel
    {
        public ProjectModel()
        {
        }

        public ProjectModel(string name, string description, string teltphoneNumber, string email, string adress, string ImagePath)
        {
            Name = name;
            Description = description;
            TeltphoneNumber = teltphoneNumber;
            Email = email;
            Adress = adress;
            this.ImagePath = ImagePath;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string Name { get; set; }
        public string Description { get; set; }
        public string TeltphoneNumber { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string ImagePath   { get; set; }
    }
}
