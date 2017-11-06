using System;
using System.Collections.Generic;
using Data.Domain.Entities;

namespace Data.Domain.Interfaces
{
    public interface IMenuCardRepository
    {
        IReadOnlyList<MenuCard> GetAll();
        MenuCard GetById(Guid id);
        void Add(MenuCard menuCard);
        void Edit(MenuCard menuCard);
        void Delete(Guid id);
    }
}
