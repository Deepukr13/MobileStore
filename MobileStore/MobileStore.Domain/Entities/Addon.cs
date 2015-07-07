using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MobileStore.Domain.Entities
{
    public class Addon
    {
        public int AddonId { get; set; }
        public string AddonName{get;set;}
        public string AddonType{get;set;}
           public string AddonDec{get;set;}
           public int ProductID { get; set; }
           public virtual Product Product { get; set; }
    }
}
