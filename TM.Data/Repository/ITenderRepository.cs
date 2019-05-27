using System;
using System.Collections.Generic;
using System.Text;

namespace TM.Data.Repository
{
    public interface ITenderRepository
    {
        List<Tender> GetAll();

        List<Tender> Create(Tender tender);

        List<Tender> Update(Tender tender);

        Tender Get(int id);

        void Delete(int id);
    }
}
