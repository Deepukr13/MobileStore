using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobileStore.Domain.Entities;
using System.Threading.Tasks;

namespace MobileStore.Domain.Abstract
{
  public  interface IAddonRepository
    {
      IQueryable<Addon> Addons { get; }

    }
}
