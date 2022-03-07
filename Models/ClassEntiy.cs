using System.Collections.Generic;

namespace Mvc.Models
{
    public class ClassEntiy
    {

        public int ID { get; set; }

        public string ClassName { get; set; }

        //virtual,主要是用于延迟加载，提高性能用的
        //只有定义成virtual后才可以延迟加载。
        public virtual ICollection<Student> Students { get; set; }

    }
}
