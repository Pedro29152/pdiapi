using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdiApi.Models.Util
{
    public class Paginated<T> where T : BaseModel
    {
        public Paginated(int Page, int Size, int CompleteSize, IList<T> Data)
        {
            this.Page = Page;
            this.Size = Size;
            this.CompleteSize = CompleteSize;
            this.Data = Data;
        }

        public int Page { get; set; }
        public int Size { get; set; }
        public int CompleteSize { get; set; }
        public IList<T> Data { get; set; }
    }
}
