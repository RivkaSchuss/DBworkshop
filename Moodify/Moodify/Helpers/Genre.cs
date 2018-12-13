using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.Helpers
{
    public class Genre
    {
        private string genreName;

        public string GenreName
        {
            set
            {
                this.genreName = value;
            }
            get
            {
                return this.genreName;
            }
        }


    }


}
