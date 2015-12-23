using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace PagingControlProject.Database
{
    using System.ComponentModel;
    using Custom_Control;

    public class MyService : IPageControlContract
    {
        List<Student> studentList = new List<Student>();

        public MyService()
        {
            Student studentObj;
            Random randomObj = new Random();

            for (int i = 0; i < 1000; i++)
            {
                studentObj = new Student();
                studentObj.FirstName = "First " + i;
                studentObj.MiddleName = "Middle " + i;
                studentObj.LastName = "Last " + i;
                studentObj.Age = (int)randomObj.Next(1, 100);

                studentList.Add(studentObj);
            }
        }

        #region IPageControlContract Members

        public int GetTotalCount()
        {
            return studentList.Count;
        }

        public ICollection<object> GetRecordsBy(int startingIndex, int numberOfRecords, object sortData)
        {
            var filter = (SortData)sortData;

            if (filter?.ListSortDirection == null)
            {
                return studentList
                    .Skip(startingIndex)
                    .Take(numberOfRecords)
                    .ToList<object>();
            }
            else
            {
                var sortDirectionStr = filter.ListSortDirection == ListSortDirection.Ascending ? "ASC" : "DESC";
                // Ordenación aquí
                return studentList.OrderBy(filter.ColumnName + " " + sortDirectionStr)
                    .Skip(startingIndex)
                    .Take(numberOfRecords)
                    .ToList<object>();
            }
        }

        #endregion
    }  
}
