﻿using Gestion_de_etudiant.Models;

namespace Gestion_de_etudiant.Repositories
{
    public interface IStudentRepository
    {
        IList<Student> GetAll();
        Student GetById(int id);
        void Add(Student s);
        void Edit(Student s);
        void Delete(Student s);
        IList<Student> GetStudentsBySchoolID(int? schoolId);
        IList<Student> FindByName(string name);
    }
}
