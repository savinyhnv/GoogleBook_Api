using EdenLab.Core.Entities;
using EdenLab.Core.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TestTask.Creatio.Core.Abstractions.Repositories;
using TestTask.Creatio.Data.Entities;

namespace TestTask.Creatio.Core.Repositories
{
    public class AuthorRepository : EntityRepositoryBase<ELBaseAuthor>, IAuthorRepository
    {

        private readonly IDbConnection _dbConnection;

        public AuthorRepository(IDbContext dbContext, IDbConnection dbConnection) : base(dbContext) 
        {
            this._dbConnection = dbConnection;
        }

        public List<Guid> AddAuthors(List<ELBaseAuthor> author)
        {
            var idList = new List<Guid>();

            foreach (var authorItem in author)
            {
                var id = _dbContext.Entry<ELBaseAuthor>().Add(authorItem);
                idList.Add(id);
            }

            return idList;
        }

        public bool IsAuthorExistsByName(string name) => _dbContext.Entry<ELBaseAuthor>().Any(author => author.ELName == name);
        public Guid GetAuthorIdByName(string name) => _dbContext.Entry<ELBaseAuthor>().FirstOrDefault(author => author.ELName == name).Id;
        public ELBaseAuthor GetAuthorNyName(string name) => _dbContext.Entry<ELBaseAuthor>().FirstOrDefault(author => author.ELName == name);
        
    }
}
