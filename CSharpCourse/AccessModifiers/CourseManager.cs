using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    class CourseManager
    {
        public void Add()
            {
                //Course ana projede internal olduğu için burada kullanılabildi.
                Course course = new Course();
            }
    }
}
