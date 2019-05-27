using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TM.Data.Repository
{
    public class TenderRepository : ITenderRepository
    {
        readonly TenderDbContext _context;

        public TenderRepository(TenderDbContext tenderDbContext)
        {
            _context = tenderDbContext;
        }
        public List<Tender> GetAll()
        {
            return this._context.Tenders.ToList();
        }

        public List<Tender> Create(Tender tender)
        {
            this._context.Tenders.Add(tender);
            this._context.SaveChanges();

            return this._context.Tenders.ToList();
        }

        public Tender Get(int id)
        {
            return this._context.Tenders.Where(i => i.TenderId == id).SingleOrDefault();

        }

        public void Delete(int id)
        {
            var tender = this._context.Tenders.Where(i => i.TenderId == id).SingleOrDefault();
            this._context.Tenders.Remove(tender);
        }

        public List<Tender> Update(Tender tender)
        {
            var tenderToUpdate = this._context.Tenders.Where(i => i.TenderId == tender.TenderId).SingleOrDefault();
            tenderToUpdate.Title = tender.Title;
            tenderToUpdate.ReferenceNumber = tender.ReferenceNumber;
            tenderToUpdate.ReleaseDate = tender.ReleaseDate;
            tenderToUpdate.ClosingDate = tender.ClosingDate;
            tenderToUpdate.Description = tender.Description;

            this._context.Update(tenderToUpdate);

            return this._context.Tenders.ToList();
        }

    }
}
