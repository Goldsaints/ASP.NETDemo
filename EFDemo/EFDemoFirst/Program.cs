using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemoFirst
{
    class Program
    {
        static void Main(string[] args)
        {

            //获取sql连接字符
            string str = System.Configuration.ConfigurationManager.ConnectionStrings["MyTestEntities"].ConnectionString;
            //把str 解密 

            MyTestEntities dbContext = new MyTestEntities();

            #region add
            //News news = new News();
            //news.Content = "content";
            //news.TitleName = "TitleNmae";
            //dbContext.News.Add(news);
            //dbContext.SaveChanges();
            #endregion

            #region Update
            //News news = new News();
            //news.Content = "content";
            //news.TitleName = "a22a";
            //news.ID = 1;
            //修改一行数据
            //dbContext.Entry<News>(news).State = System.Data.EntityState.Modified;
            // System.Data.EntityState.Detached 不跟踪实体，dbContext可以继续用，可以被回收

            //只修改某一列
            //dbContext.News.Attach(news);//附加到上下文操作来管理
            //dbContext.Entry<News>(news).Property("TitleName").IsModified = true;
            // 或者 dbContext.Entry<News>(news).Property<string>(u => u.TitleName).IsModified = true; 

            #endregion

            #region Delect
            //News news = new News();
            //news.ID = 3; 或者
            //News news = new News() { ID = 3 };
            //dbContext.Entry<News>(news).State = System.Data.EntityState.Deleted;
            #endregion

            #region SelectAll
            //foreach (var news in dbContext.News) {
            //    Console.WriteLine(news.ID + "" + news.Content);
            //}
            #endregion

            #region Linq 查询
            // u 遍历  dbContext.News 高效的sql脚本，NetFramework3.0后。 返回的类型为Iqueryable<News>
            var temp = from n in dbContext.News
                       where n.ID == 4
                       select n;

            /**
             *协变，把一个子类的泛型集合赋值给父类的泛型集合，外面只能用父类泛型，安全使用集合
             * List<int> llist = new List<int>(){1,2,3};
             * List<object> listobj = listInt; 
             */

            foreach (var n in dbContext.News)
            {
                Console.WriteLine(n.ID + "" + n.Content);
            }
            #endregion

            dbContext.SaveChanges();
            Console.ReadKey();

        }
    }
}
