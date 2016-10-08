using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using ZoolandiaRazor.Models;

namespace ZoolandiaRazor.DAL
{
    public class ZooRepository
    {
        //property
        public ZooContext Context { get; set; }

        //constructor
        public ZooRepository()
        {
            Context = new ZooContext();
        }

        //injection
        public ZooRepository(ZooContext _context)
        {
            Context = _context;
        }
        

    }
}