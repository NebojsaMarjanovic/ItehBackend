using DataAccessLayer.Implementations;
using DataAccessLayer.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        //dependency injection
        private readonly Context context;

        public UnitOfWork(Context context)
        {
            this.context = context;
            AdminRepository = new AdminRepository(context);
            GradRepository = new GradRepository(context);
            KlijentRepository = new KlijentRepository(context);
            RezervacijeRepository = new RezervacijaRepository(context);
            UserRepository = new UserRepository(context);
        }

        public IAdminRepository AdminRepository { get; set; }
        public IGradRepository GradRepository { get; set; }
        public IKlijentRepository KlijentRepository { get; set; }
        public IRezervacijeRepository RezervacijeRepository { get; set; }
        public IUserRepository UserRepository { get; set; } 

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
