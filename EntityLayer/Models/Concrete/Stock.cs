//using EntityLayer.Concrete;
//using EntityLayer.Models.Abstract;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//Since inventory management wasn't complex, the Stock entity was deleted, and instead, a stock quantity field was added within the Product entity.

//namespace EntityLayer.Models.Concrete
//{
//    public class Stock : BaseEntity
//    {
//        public string StockCode { get; set; }
//        public string StockName { get; set; }
//        public string Description1 { get; set; }
//        public string Description2 { get; set; }
//        public decimal Price { get; set; }
//        public int Quantity { get; set; }
//        public string Unit { get; set; }
//        public List<Category> Categories { get; set; }
//    }
//}
