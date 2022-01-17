using System;
using System.Collections.Generic;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Core.Abstractions.Services
{
    public interface IAuthorService
    {
        bool IsAuthorExistsByName(string name);
        Guid GetAuthorIdByName(string name);
        ELBaseAuthor GetAuthorByName(string name);
        void AddNewAuthor(ELBaseAuthor author);
    }
}
