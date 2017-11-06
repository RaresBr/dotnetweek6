using System;
using System.Collections.Generic;
using System.Linq;
using Data.Domain.Entities;
using Data.Domain.Interfaces;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Busines
{
    public class MenuCardRepository : IMenuCardRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public MenuCardRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IReadOnlyList<MenuCard> GetAll() => _databaseContext.MenuCards.ToList();

        public IQueryable<MenuCard> GetAllEager() => _databaseContext.MenuCards.Include("Menus");

        public MenuCard GetById(Guid id) => _databaseContext.MenuCards.FirstOrDefault(t => t.Id == id);

        public void Add(MenuCard menuCard)
        {
            _databaseContext.MenuCards.Add(menuCard);
            _databaseContext.SaveChanges();
        }

        public void Edit(MenuCard menuCard)
        {
            _databaseContext.MenuCards.Update(menuCard);
            _databaseContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var menuCard = GetById(id);
            if (menuCard != null)
            {
                _databaseContext.MenuCards.Remove(menuCard);
                _databaseContext.SaveChanges();
            }
        }
    }
}

