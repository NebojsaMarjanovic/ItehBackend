using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IAdminRepository AdminRepository { get; set; }
        public IGradRepository GradRepository { get; set; }
        public IKlijentRepository KlijentRepository { get; set; }
        public IRezervacijeRepository RezervacijeRepository { get; set; }
        public IUserRepository UserRepository { get; set; }

        public void Save();
    }
}
