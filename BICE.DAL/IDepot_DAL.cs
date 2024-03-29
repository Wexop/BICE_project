﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICE.DAL
{
    public interface IDepot_DAL<Type_DAL>
    {
        public Type_DAL Insert(Type_DAL p);
        public Type_DAL Update(Type_DAL p);
        public void Delete(string id);
        public void Delete(int id);
        public Type_DAL GetById(int id);
        public Type_DAL GetById(string id);
        public IEnumerable<Type_DAL> GetAll();
    }
}
