using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Data.Domain.Entities
{
    public class MenuCard
    {
        private MenuCard()
        {
        }

        public Guid Id { get; private set; }
        [MinLength(1)]
        public string Title { get; private set; }
        public List<Menu> Menus { get; private set; }
        public string AllergyInfo { get; private set; }

        public static MenuCard Create(string title,string info, List<Menu> menus)
        {
            var instance = new MenuCard {Id = Guid.NewGuid(), Menus = new List<Menu>()};
            instance.Update(title,info,menus);
            return instance;
        }

        public  void Update(string title, string info, List<Menu> menus)
        {
            Title = title;
            Menus = menus.ToList();
            AllergyInfo = info;
        }

    }
}
