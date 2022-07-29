using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.App.Service.HashPassword
{
    public interface IHashingPasswordService
    {
        string Hash(string password);
    }
}
