using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobileStore.Domain.Entities;
using MobileStore.Domain.Abstract;
using System.Threading.Tasks;

namespace MobileStore.Domain.Concrete
{
    public class EFAddonRepository : IAddonRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Addon> Addons
        {

            get { return context.Addons; }

        }
    }
}