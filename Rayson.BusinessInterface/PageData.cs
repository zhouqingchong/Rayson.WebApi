using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rayson.BusinessInterface
{
    public class PageData<T> where T : class
    {
        /// <summary>
        /// 总数量
        /// </summary>
        public int Total { get; set; }
        //页大小
        public int PageSize { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 当前页数据集合
        /// </summary>
        public List<T>? DataList { get; set; }
    }
}
