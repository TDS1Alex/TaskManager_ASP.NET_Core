using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.App.Dtos
{
    public class ListDto <T>
    {
        public int Count { get; set; }
        public T[] Items { get; set; }
    }
}
