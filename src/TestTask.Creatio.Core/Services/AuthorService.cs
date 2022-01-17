using System;
using System.Collections.Generic;
using System.Text;
using TestTask.Creatio.Core.Abstractions.Repositories;
using TestTask.Creatio.Core.Abstractions.Services;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            this._authorRepository = authorRepository;
        }


        public void AddNewAuthor(ELBaseAuthor author)
        {
            _authorRepository.Add(author);
            _authorRepository.Save();
        }
        public bool IsAuthorExistsByName(string name) => this._authorRepository.IsAuthorExistsByName(name);
        public Guid GetAuthorIdByName(string name) => this._authorRepository.GetAuthorIdByName(name);
        public ELBaseAuthor GetAuthorByName(string name) => this._authorRepository.GetAuthorNyName(name);
    }
}
