﻿using Gestion_de_etudiant.Models;

namespace Gestion_de_etudiant.Repositories
{
    public interface ISchoolRepository
    {
        IList<School> GetAll();
        School GetById(int id);
        void Add(School s);
        void Edit(School s);
        void Delete(School s);
        double StudentAgeAverage(int schoolId);
        int StudentCount(int schoolId);
    }
}
